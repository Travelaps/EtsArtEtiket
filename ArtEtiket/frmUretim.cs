using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using ArtEtiket.DAL;
using Newtonsoft.Json.Linq;

namespace ArtEtiket
{
    public partial class frmUretim : Form
    {
        #region Deişkenler
        readonly char _decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        readonly string _teraziModel = Properties.Settings.Default.TeraziModel;
        //Comport Ayarları;
        readonly string _comPort = Properties.Settings.Default.ComPort;
        readonly int _comPortBaudRate = Properties.Settings.Default.ComPort_BaudRate;
        readonly bool _teraziBilgiIncelemeAktif = Properties.Settings.Default.TeraziBilgiIncelemeAktif;

        readonly int _timer1Sure = Properties.Settings.Default.TeraziBilgiAlmaSuresi_msec;
        readonly int _timer2Sure = Properties.Settings.Default.TeraziBilgiAlmaSuresi2_msec;

        //string okunanStr;
        //string[] okunanStrArray;
        List<string> okunan = new List<string>();
        List<string> okunan_LOG = new List<string>();

        public int StokGrupButonYukseklik = Properties.Settings.Default.StokGrupButonYukseklik;
        public int StokGrupButonGenislik = Properties.Settings.Default.StokGrupButonGenislik;
        public int StokGrupSatirSayisi = Properties.Settings.Default.StokGruplariSatirSayisi;
        


        public int StokButonYukseklik = Properties.Settings.Default.StokButonYukseklik;
        public int StokButonGenislik = Properties.Settings.Default.StokButonGenislik;

        public bool StokKodunuGoster = Properties.Settings.Default.StokKodunuGoster;

        public bool KoliSistemiAktif = Properties.Settings.Default.KoliSistemiAktif;
        public bool MamulGrupButonlariAktif = Properties.Settings.Default.MamulGrupButonlariAktif;
        public bool SubeButonlariAktif = Properties.Settings.Default.SubeButonlariAktif;

        public bool Onizleme = Properties.Settings.Default.Onizleme;
        public string VarsayilanEtiket = Properties.Settings.Default.VarsayilanEtiket;
        #endregion
        Nodejs api;
        public frmUretim()
        {
            InitializeComponent();
            try
            {
                _comPortBaudRate = Convert.ToInt32(Properties.Settings.Default.ComPort_BaudRate);
            }
            catch (Exception)
            {
                _comPortBaudRate = 9600;
            }
            api = new Nodejs();
            serialPort1.PortName = _comPort;
            serialPort1.BaudRate = _comPortBaudRate;
            OpenPort();

            timer1.Interval = _timer1Sure;
            timer2.Interval = _timer2Sure;

            //rtbOkunan.Visible = TeraziBilgiIncelemeAktif;
            rtbLOG.Visible = _teraziBilgiIncelemeAktif;

            pnlMamulGruplari.Visible = true;//MamulGrupButonlariAktif;
            pnlSubeler.Visible = SubeButonlariAktif;

            pnlKoliIslem.Visible = KoliSistemiAktif;

            //ScrollBar vScrollBar1 = new VScrollBar();
            //vScrollBar1.Dock = DockStyle.Right;
            //vScrollBar1.Scroll += (sender, e) => { pnlMamuller.VerticalScroll.Value = vScrollBar1.Value; };
            //pnlMamuller.Controls.Add(vScrollBar1);
            #region Nodejs
              //UretimTalebiniOtomatikOlustur = dbOperation.ReadConfigParam("ArtEtiket", "Uretim", "Uretim Talebini Otomatik Olustur", "1") == "1";
              //UretimTalepDepoId = dbOperation.DepoIDbul(dbOperation.ReadConfigParam("ArtEtiket", "Uretim", "Uretim Talep Fisi Deposu", "ÜRETİM"));
            #endregion

        }

        #region SeriPort islemleri

        public void OpenPort()
        {
            rtbOkunan.Clear();
            okunan_LOG.Clear();
            try
            {
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    okunan_LOG.Add("Seri port opened");
                }
            }
            catch (Exception)
            {
                txtMiktar.Text = "BAĞLANAMADI";
                txtMiktar.BackColor = Color.Red;
            }
            
        }
        public void ClosePort()
        {
            if (serialPort1.IsOpen)
            {
                okunan_LOG.Add("serialPort1.Closed ONCESIIII");
                try
                {
                    serialPort1.Close();
                }
                catch (Exception e)
                {
                    okunan_LOG.Add("exception port closee :" + e.Message);
                }
                okunan_LOG.Add("serialPort1.Closed");
            }
        }

        private void frmUretim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void Timer2Tick(object sender, EventArgs e)
        {
             
            if (serialPort1.BytesToRead > 0)
            {
                rtbOkunan.Text += serialPort1.ReadExisting();
            }
        }
        private void Timer1Tick(object sender, EventArgs e)
        {
            //okunanStrArray = okunanStr.Split((char)10);
         
            okunan_LOG.Add("Timer ticked" + (char)13);
            timer1.Enabled = false;
            timer2.Enabled = false;

            //rtbOkunan.Lines = okunanStrArray;
            okunan = rtbOkunan.Lines.ToList();

            //foreach (var s in okunan)
            //{
            //    MessageBox.Show("aaaa:" + s);
            //}

            rtbLOG.Lines = okunan_LOG.ToArray();

            okunan_LOG.Add("ClosePort oncesı" + (char)13);
            System.Threading.Thread.Sleep(100);
            ClosePort();

            System.Threading.Thread.Sleep(100);
            okunan_LOG.Add("ClosePort sonrasi" + (char)13);



            string KG = "ERROR";

            bool res = Check10LinesData();
            if (res)
            {
                KG = (res) ? GetKgFromLine(okunan[0]) : "ERROR";
                okunan_LOG.Add("KG : " + KG + (char)13);
            }

            txtMiktar.Text = KG;
            txtMiktar.BackColor = (
                KG == "ERROR" 
                || KG.Substring(0,2) == "BA"
                || KG == "-  0.000"
                || KG == "   0.000"
                || KG == "-  0,000"
                || KG == "   0,000"
                || KG == "  0,000"
                || KG == "  0.000"
                ) ? Color.Red : Color.LightGreen;

            //buttonStart_Click(sender, e);
            OpenPort();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        public bool Check10LinesData()
        {
            //okunan = okunanStrArray.ToList();
            okunan_LOG.Add("Check10linesData" + (char)13);

            if (Properties.Settings.Default.TeraziBilgiIncelemeAktif)
                MessageBox.Show("check10lines girdi: " +okunan.ToString());

            //IMREN terazi zaten yavaş ilk satir da lazım 
            //if (okunan.Count > 0)
            //    okunan.RemoveAt(0); //ilk satir BOZUK GELİYORRR

            int i = 0;

            while (i < okunan.Count)  //kaç satır gelmişse hepsini dönüp bakalım KG ne kadar
            {
                switch (_teraziModel)
                {
                    case "30KG":

                        if (  
                            (okunan[i].Length >= 6 && okunan[i].Substring(0, 6) != "Net Ag")
                            || (okunan[i].Contains("Dara"))
                            || (okunan[i].Length < 2)
                            )
                            okunan.RemoveAt(i);
                        else
                            i++;
                        break;

                    case "100KG":

                        if (okunan[i].Length >= 2 && okunan[i].Substring(0, 2) != "ST")
                            okunan.RemoveAt(i);
                        else
                            i++;
                        break;

                    case "CAS":

                        if (okunan[i].Length < 9 || okunan[i].Substring(0, 1) != "S")
                            okunan.RemoveAt(i);
                        else
                            i++;
                        break;

                    default:
                        break;
                }
            }

            //foreach (var s in okunan)
            //{
            //    MessageBox.Show(s);
            //}
            if (Properties.Settings.Default.TeraziBilgiIncelemeAktif)
                MessageBox.Show("check10lines arada: " + okunan.ToString());

            bool eq10 = okunan.Count >= ((_teraziModel == "100KG") ? 10 : 2);
            if (eq10)
            {
                okunan = okunan.Take(10).ToList();
                string satir = okunan[0].ToString();

                foreach (var l in okunan)
                {
                    if (Properties.Settings.Default.TeraziBilgiIncelemeAktif)
                        MessageBox.Show("check10lines satirlar kontrol ediliyor: " + satir + " <> " + l.ToString());
                    if (eq10)
                        eq10 = (l == satir);
                }

                if (Properties.Settings.Default.TeraziBilgiIncelemeAktif)
                    MessageBox.Show(eq10 ? "eq10 evet" : "eq10 HAYIR");

            }
            return eq10;
        }

        public string GetKgFromLine(string line)
        {
            okunan_LOG.Add("GetKGFromLine : " + line + (char)13);
            //100KG
            //01234567890123456
            //ST,GS,   1.160,kg

            //30KG
            //01234567890123456
            //Net Ag.:  1.160kg

            //IMREN 30KG
            //01234567890123456
            //S  0.160kg
            var kg = "";
            switch (_teraziModel)
            {
                case "100KG": kg = line.Substring(6, 8); break;
                case "30KG": kg = line.Substring(8, 7); break;
                case "CAS": kg = line.Substring(1, 7); break;
                default:
                    break;
            }

            kg = kg.Replace('.', _decimalSeparator).Replace(',', _decimalSeparator);

            if (Properties.Settings.Default.TeraziBilgiIncelemeAktif)
              MessageBox.Show("kg : "+kg);

            return kg;
        }



        #endregion

        private SqlProvider _sqlProvider;
        private bool KoliAktif=false;
        private int koliStokid=0;
        private double koliToplami=0;
        private int koliIciAdet=0;
        private int koliGrupID=0;
        private string BarkodPrinterName = Properties.Settings.Default.BarkodPrinterName;
        private string etiketsubeadi="";

        private int UretimTalepDepoId = 0;
        private bool UretimTalebiniOtomatikOlustur = false;

        public void MenuRefresh()
        {
            string ilkgrup = null;
            if (pnlMamulGruplari.Visible)
                ilkgrup = MamulGrupButonlariniCiz();

            MamulButonlariniCiz(0, ilkgrup);

            if (pnlSubeler.Visible)
                SubeButonlariniCiz();
        }

        private void frmUretim_Load(object sender, EventArgs e)
        {
            string ilkgrup = null;
            if (pnlMamulGruplari.Visible)
                ilkgrup = MamulGrupButonlariniCiz();

            MamulButonlariniCiz(0,ilkgrup);

            if (pnlSubeler.Visible)
                SubeButonlariniCiz();

            #region 2.Adım >> ETİKET TASARIM larını sağ panelde Butonlar Halinde Göster

            //DirectoryInfo info = new DirectoryInfo(Application.StartupPath + "\\Raporlar");
            //FileInfo[] fi = info.GetFiles();
            //foreach (FileInfo str in fi)
            //{
            //    Button btn = new Button();
            //    btn.Height = 80;
            //    btn.Width = 200;
            //    //btn.Tag =0;
            //    btn.Text = str.Name;
            //    if (str.Name.EndsWith(".frx"))
            //    {

            //    }
            //    else
            //    {
            //        string yol = str.FullName;
            //        btn.BackgroundImageLayout=ImageLayout.Stretch;
            //        btn.BackgroundImage = Image.FromFile(yol);
            //    }

            //    pnlEtiketler.Controls.Add(btn);
            //}

            #endregion
        }

        private void frmUretim_Close(object sender, EventArgs e)
        {
            // frmMain.MenuBar.Visible = true;
        }

        #region YarıMamulGrup ve YarıMamul Butonları
        public string MamulGrupButonlariniCiz()
        {
            var ilkgrup = "";
            //string BtnTag = "GROUPCODE", btnText = "GROUPNAME";
            string BtnTag = "ID", btnText = "NOTES";

            pnlMamulGruplari.Height = (StokGrupSatirSayisi * StokGrupButonYukseklik) + 10;

        #region 1.adım >> MAMUL GRUPLARI Alt Panelde Butonlar Halinde Göster
        //Once varolan butonları silelim
        pnlMamulGruplari.Controls.Clear();

            // Üretimi yapılan Mamul Grupları: S91 ile başlayanlar
            // Bu mamul gruplarını Altta Butonlar olarak gösterelim , seçip ilgili Mamulleri ekrana getireceğiz

            

            api.Login();

            var dataset  = api.GetDataSet(/*this.GetStockGroup()*/ this.GetProductionFiches());
            

            System.Data.DataTable StockGroupDTable = dataset.Tables["datatable1"];

            
            #region Nodejs
            /*_sqlProvider = new SqlProvider(
               " SELECT STOKGRUPID,KODU,ADI " +
               " FROM STOKGRUP " +
               " WHERE TURU = 'STOK' " +
               "   AND KODU LIKE 'S91%' " +
               "   AND KODU IN (SELECT GRUP FROM STOK WHERE KODU LIKE 'S91%' AND HLISTE=1)" +
               " ORDER BY KODU "
             );*/
            #endregion

            var dt = new DataTable();

            dt = StockGroupDTable;
            //dt.Load(_sqlProvider.ExecuteReader());
            foreach (DataRow row in dt.Rows)
            {
                if (ilkgrup == "")
                    ilkgrup = row[BtnTag].ToString();//row["KODU"].ToString();

                var btn = new Button
                {
                    Height = StokGrupButonYukseklik ,
                    Width =  StokGrupButonGenislik,
                    Tag = row[BtnTag],//row["KODU"],
                    Text = row[btnText].ToString(),//row["GROUPNAME"].ToString(),

                    /*BackColor =

                    (

                    //EKMEKICI
                    row["GROUPNAME"].ToString().Contains("SOS") ? Color.LightSteelBlue :
                    row["GROUPNAME"].ToString().Contains("PİLİÇ DÖNER") ? Color.LimeGreen :
                    row["GROUPNAME"].ToString().Contains("PİLİÇ") ? Color.Yellow :
                    row["GROUPNAME"].ToString().Contains("ET D") ? Color.PaleVioletRed :
                    row["GROUPNAME"].ToString().Contains("KEBAP") ? Color.LightSalmon :
                    row["GROUPNAME"].ToString().Contains("KÖFTE") ? Color.OrangeRed :
                    row["GROUPNAME"].ToString().Contains("KIYMA") ? Color.Turquoise :
                    row["GROUPNAME"].ToString().Contains("DANA") ? Color.HotPink :

                    //IMREN
                    row["GROUPNAME"].ToString().Contains("SAKIZ") ? Color.LightSteelBlue :
                    row["GROUPNAME"].ToString().Contains("PROF") ? Color.LimeGreen :
                    row["GROUPNAME"].ToString().Contains("PASTA") ? Color.Yellow :
                    row["GROUPNAME"].ToString().Contains("ET D") ? Color.PaleVioletRed :
                    row["GROUPNAME"].ToString().Contains("KEBAP") ? Color.LightSalmon :
                    row["GROUPNAME"].ToString().Contains("KÖFTE") ? Color.OrangeRed :
                    row["GROUPNAME"].ToString().Contains("KIYMA") ? Color.Turquoise :
                    row["GROUPNAME"].ToString().Contains("DANA") ? Color.HotPink :

                    Color.White
                                  )*/
                };
                 btn.Click += new EventHandler(btn_MamulGrupClick);
                 pnlMamulGruplari.Controls.Add(btn);
            }
            return ilkgrup;
            #endregion
        }
         
        public JObject GetStockGroup()
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";
       
            obj["Object"] = "QA_STOCK_SEMIPRODUCT_GROUPS";// 
            obj["LoginToken"] = api.LoginToken;
            //MessageBox.Show(api.LoginToken);
           /* var where = new JArray();
            obj["Where"] = where;

            var where1 = new JObject();
            where1["Column"] = "STOCKTYPE";
            where1["Operator"] = "=";
            where1["Value"] = "1";
            where.Add(where1);*/

            return obj;
        }
        public JObject GetProductionFiches() 
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";

            obj["Object"] = "QA_STOCK_PRODUCTIONFICHES_NOT_COMPLETE";//  
            obj["LoginToken"] = api.LoginToken;
            //MessageBox.Show(api.LoginToken);
            /* var where = new JArray();
             obj["Where"] = where;

             var where1 = new JObject();
             where1["Column"] = "STOCKTYPE";
             where1["Operator"] = "=";
             where1["Value"] = "1";
             where.Add(where1);*/

            return obj;
        }
        public JObject GetProductionFichesDetails(string FicheId =null)
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";
            obj["Object"] = "QA_STOCK_PRODUCTIONFICHEDETAILS_NOT_COMPLETE";
            obj["LoginToken"] = api.LoginToken;

            var where = new JArray();
            obj["Where"] = where;

           /* var where1 = new JObject();
            where1["Column"] = "STOCKTYPE";
            where1["Operator"] = "=";
            where1["Value"] = "1";*/

            var where2 = new JObject();

            if (FicheId != null)
            {
                where2["Column"] = "FICHEID";
                where2["Operator"] = "=";
                where2["Value"] = FicheId;
                where.Add(where2);
            }
            //where.Add(where1);

            return obj;
        }



        public JObject GetProduct(JObject Where = null)
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";
            obj["Object"] = "STOCK_STOCK";
            obj["LoginToken"] = api.LoginToken;
            //MessageBox.Show(api.LoginToken);
            var where = new JArray();
            obj["Where"] = where;

            var where1 = new JObject();

            if (Where!=null)
            {
                where1 = Where;

                where.Add(where1);

            }

            return obj;
        }
        void btn_MamulGrupClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var grupkodu = btn.Tag.ToString();
            MamulButonlariniCiz(0, grupkodu);
        }
        void MamulButonlariniCiz(int stokid, string grupkodu = null)
        {
            #region 1.adım >> MAMULLERİ Sol Panelde Butonlar Halinde Göster
            //Once varolan butonları silelim
            pnlMamuller.Controls.Clear();

            //Üretimi yapılan Son Mamuller: Hızlı Listede olanlar ve S91 ile başlayanlar
            // Bu mamulleri Solda Butonlar olarak gösterelim , seçip ETIKET basacağız 
            /*_sqlProvider = new SqlProvider(
                "SELECT STOKID,KODU,ADI,UPPER(BIRIM) BIRIM FROM STOK WHERE KODU LIKE 'S91%' AND HLISTE=1"
              + ((stokid > 0) ? " AND STOKID = " + stokid.ToString() : "")
              + ( (grupkodu != null) ? " AND GRUP = '"+grupkodu+"' " : "" )
              + "ORDER BY ADI"
              );*/
           
           //  var dataset = api.GetDataSet(GetStock(grupkodu));
            var dataset = api.GetDataSet(GetProductionFichesDetails(grupkodu));

            System.Data.DataTable StockDTable = dataset.Tables["datatable1"];

            var dt = new DataTable();

            dt = StockDTable;

            //dt.Load(_sqlProvider.ExecuteReader());

            int Yuk = StokButonYukseklik;
            int Gen = StokButonGenislik;
            int FontSize = 12;

            
            if (dt.Rows.Count > 9000)
            {
                Yuk = (int)(StokButonYukseklik * 0.66);
                Gen = (int)(StokButonGenislik * 0.56);
                FontSize = 6;
            }
            else
            if (dt.Rows.Count > 49)
            {
                Yuk = (int)(StokButonYukseklik * 0.72);
                Gen = (int)(StokButonGenislik * 0.68);
                FontSize = 8;
            }
             

            //int Yuk = (dt.Rows.Count > 49) ? (int)(StokButonYukseklik * 0.72) : StokButonYukseklik;
            //int Gen = (dt.Rows.Count > 49) ? (int)(StokButonGenislik * 0.68) : StokButonGenislik;
            //int FontSize = (dt.Rows.Count > 49) ? 8 : 12;

            foreach (DataRow row in dt.Rows)
            {
                var btn = new Button
                {
                    Height = Yuk * ((stokid > 0) ? 3 : 1),
                    Width = Gen * ((stokid > 0) ? 3 : 1),
                    Tag = row["ID"],
                    Text = 
                    ((StokKodunuGoster) ? row["STOCKCODE"].ToString() + "\n" : "")
                    + row["NAME"].ToString() 
                    + ((row["UNITNAME"].ToString() == "ADET") ? "\n" + "(ADET)" : ""),

                    /*BackColor =

                    (
                    //EKMEKICI
                    row["GROUPNAME"].ToString().Contains("SOS") ? Color.LightSteelBlue :
                    row["GROUPNAME"].ToString().Contains("PİLİÇ DÖNER") ? Color.LimeGreen :
                    row["GROUPNAME"].ToString().Contains("PİLİÇ") ? Color.Yellow :
                    row["GROUPNAME"].ToString().Contains("ET D") ? Color.PaleVioletRed :
                    row["GROUPNAME"].ToString().Contains("KEBAP") ? Color.LightSalmon :
                    row["GROUPNAME"].ToString().Contains("KÖFTE") ? Color.OrangeRed :
                    row["GROUPNAME"].ToString().Contains("KIYMA") ? Color.Turquoise :
                    row["GROUPNAME"].ToString().Contains("DANA") ? Color.HotPink :

                    //IMREN
                    row["GROUPNAME"].ToString().Contains("SAKIZ") ? Color.LightSteelBlue :
                    row["GROUPNAME"].ToString().Contains("PROF") ? Color.LimeGreen :
                    row["GROUPNAME"].ToString().Contains("PASTA") ? Color.Yellow :
                    row["GROUPNAME"].ToString().Contains("ET D") ? Color.PaleVioletRed :
                    row["GROUPNAME"].ToString().Contains("KEBAP") ? Color.LightSalmon :
                    row["GROUPNAME"].ToString().Contains("KÖFTE") ? Color.OrangeRed :
                    row["GROUPNAME"].ToString().Contains("KIYMA") ? Color.Turquoise :
                    row["GROUPNAME"].ToString().Contains("DANA") ? Color.HotPink :
                    row["GROUPNAME"].ToString().Contains("EKMEK") ? Color.SkyBlue :
                    row["GROUPNAME"].ToString().Contains("POĞAÇA") ? Color.LightCoral :

                    Color.White
                                  )*/
                };
                btn.Click += new EventHandler(btn_MamulClick);
                btn.Font  = new Font(btn.Font.FontFamily, FontSize);
                pnlMamuller.Controls.Add(btn);
            }
            #endregion
        }

        public JObject GetStock(string grupCode=null)
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";
            obj["Object"] = "QA_STOCK";
            obj["LoginToken"] = api.LoginToken;

            var where = new JArray();
            obj["Where"] = where;

            var where1 = new JObject();
            where1["Column"] = "STOCKTYPE";
            where1["Operator"] = "=";
            where1["Value"] = "1";

            var where2 = new JObject();

            if (grupCode != null)
            {
                where2["Column"] = "GROUPCODE";
                where2["Operator"] = "=";
                where2["Value"] = grupCode;
                where.Add(where2);
            }
            where.Add(where1);
            
            return obj;
        }

        void btn_MamulClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var adetUrun = (!(btn.Text.Contains("(KG)"))); //(btn.Text.Contains("(ADET)") || btn.Text.Contains("(LT)"));

            if ((txtMiktar.BackColor == Color.Red) && !(adetUrun) )
            {

            }
            else
            {
                bool islemIptal = false;
                double miktar;
                int tepsiAdedi = 1;
                double daramiktar=0;

                var stokid = Convert.ToInt32(btn.Tag.ToString());
                if (adetUrun)
                {
                    var list =  Uretim_AdetSecimAlternatifleri(stokid,"QUANTITY");
                    
                    if (list.Count > 0)
                    {
                        if (list.Count == 1 && list[0].Adet > 0)
                            miktar = list[0].Adet;
                        else
                        {
                            frmAdetSecim FAdetSecim = new frmAdetSecim(list);
                            FAdetSecim.Text = "Üretim Adedini Seçiniz.";
                            FAdetSecim.ShowDialog();
                            miktar = FAdetSecim._secilenAdet;
                            tepsiAdedi = FAdetSecim._tepsiAdedi;
                            if (FAdetSecim._secilenAdet == -999)
                                islemIptal = true;
                            FAdetSecim.Dispose();
                        }
                    }
                    else
                        miktar = 1;
                }
                else
                {
                    miktar = Convert.ToDouble(txtMiktar.Text);
                    var list = Uretim_AdetSecimAlternatifleri(stokid,"DARA");
                    if (list.Count > 0)
                    {
                        if (list.Count == 1)
                        {
                            daramiktar = list[0].Adet / 1000.0;
                            miktar = miktar - daramiktar;
                        }
                        else
                        {
                            frmAdetSecim FAdetSecim = new frmAdetSecim(list);
                            FAdetSecim.Text = "Dara Seçimini Yapınız.";
                            FAdetSecim.ShowDialog();
                            daramiktar = FAdetSecim._secilenAdet / 1000.0;
                            if (FAdetSecim._secilenAdet == -999)
                                islemIptal = true;
                            FAdetSecim.Dispose();

                            miktar = miktar - daramiktar;  //DARA sını düşüp NET ini bulalım
                        }
                    }
                }
                //buraası
                if (!islemIptal)
                {
                    #region if (KoliAktif)
                    if (KoliAktif)
                    {
                        if (koliStokid == 0)
                        {
                            koliGrupID = SiraNo.SiraNoVer("KOLIGRUP");
                            koliStokid = stokid;
                            koliToplami = 0;
                            koliIciAdet = 0;
                            MamulButonlariniCiz(koliStokid);
                        }

                        koliToplami += miktar;
                        koliIciAdet++;
                        lblKoliStokAdi.Text += koliIciAdet.ToString() + " inci okunan miktar : " + miktar.ToString() + (char)13;
                        lblKoliToplami.Text = "Koli Toplamı : " + koliToplami.ToString();
                    }
                    #endregion

                    for (int k = 1; k <= tepsiAdedi; k++)
                    {
                        EtiketBas(stokid, miktar, daramiktar, KoliAktif, koliGrupID);
                    }
                }
            }
        }

        public  List<MODEL.AdetSecimleri> Uretim_AdetSecimAlternatifleri(int stokid, string alanadi = "QUANTITY")
        {
            /*_sqlProvider = new SqlProvider(
            " SELECT ARTETIKETDETAY.*, STOK.BIRIM " +
            " FROM ARTETIKETDETAY INNER JOIN STOK ON ARTETIKETDETAY.STOKID = STOK.STOKID " +
            " WHERE ARTETIKETDETAY.STOKID = @STOKID "
             );
            _sqlProvider.AddParameter("STOKID", stokid);*/

           

            var dt = new DataTable();
           var dataset =  api.GetDataSet(Get_SCALEANDLABELDETAILS(stokid.ToString()));
            System.Data.DataTable dTable = dataset.Tables["datatable1"];
            dt = dTable;
            //dt.Load(_sqlProvider.ExecuteReader());

            List<MODEL.AdetSecimleri> list = new List<MODEL.AdetSecimleri>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (dt.Rows[0][alanadi + i.ToString()].ToString() != "")
                        if (dt.Rows[0][alanadi + i.ToString()].ToString() != "0")
                        {
                            MODEL.AdetSecimleri a = new MODEL.AdetSecimleri();
                            a.Aciklama = (((dt.Rows[0]["UNITNAME"].ToString().ToUpper() == "LT") && (alanadi == "ADET")) ? "Kap" : "Tepsi") + " No " + i.ToString();
                            a.Adet = Convert.ToInt32(dt.Rows[0][alanadi + i.ToString()].ToString());
                            a.Tur = ((dt.Rows[0]["UNITNAME"].ToString().ToUpper() == "LT") && (alanadi == "ADET")) ? "LT" : alanadi;
                            list.Add(a);
                        }
                }
            }

            return list;
        }


        public JObject Get_SCALEANDLABELDETAILS(string StockId)
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";
            obj["Object"] = "QA_STOCK_SCALEANDLABELDETAILS";
            obj["LoginToken"] = api.LoginToken;

            var where = new JArray();
            obj["Where"] = where;

            var where1 = new JObject();
            where1["Column"] = "STOCKID";
            where1["Operator"] = "=";
            where1["Value"] = StockId;

            
            where.Add(where1);

            return obj;
        }


        #endregion

        #region Şube Butonları
        void SubeButonlariniCiz()
        {
            #region 2.adım >> SUBE Sol Panelin Altına Butonlar Halinde Göster
            //Once varolan butonları silelim
            pnlSubeler.Controls.Clear();


            var dt = dbOperation.SubeListesi();
            foreach (DataRow row in dt.Rows)
            {
                var btn = new Button
                {
                    Height = pnlSubeler.Height - 5,
                    Width = (pnlSubeler.Width - dt.Rows.Count * 6) / dt.Rows.Count,
                    Text = row["SUBEKODU"].ToString()
                };
                btn.Click += new EventHandler(btn_SubeClick);
                pnlSubeler.Controls.Add(btn);
            }
            #endregion
        }
        void btn_SubeClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            etiketsubeadi = btn.Text;
        }
        #endregion

        private void EtiketBas(int stokid, double miktar, double daramiktar, bool koliicinde, int koligrupid, string partino="")
        {
            bool tekrarbasim = false;
            if (partino == "")
            {
                partino = PartiNoUret(DateTime.Now.Date);
              
            }
            else
                tekrarbasim = true;

            //_sqlProvider = new SqlProvider(

            /* " SELECT " +
             ((koligrupid > 0 && !koliicinde ) ? " 'KOLI' AS KOLI, " : " '' AS KOLI, ") +
             ((etiketsubeadi !="") ? " '"+etiketsubeadi+"' AS SUBEADI, " : " '' AS SUBEADI, ") +
             "  S.ADI,S.BIRIM,S.EK2,'' ACIKLAMA," +
             "  '28'+REPLACE(KODU,'S','')+" +
             "  CASE " +
             "    WHEN LEN(@MIKTAR*1000)=5 THEN       CONVERT(nvarchar(5),(@MIKTAR*1000))  " +
             "    WHEN LEN(@MIKTAR*1000)=4 THEN   '0'+CONVERT(nvarchar(5),(@MIKTAR*1000))  " +
             "    WHEN LEN(@MIKTAR*1000)=3 THEN  '00'+CONVERT(nvarchar(5),(@MIKTAR*1000))  " +
             "    WHEN LEN(@MIKTAR*1000)=2 THEN '000'+CONVERT(nvarchar(5),(@MIKTAR*1000))  " +
             "  END BARKOD, " +
             "  @PARTINO PARTINO," +
             "  @MIKTAR AS MIKTAR,@DARA AS DARA,@BURUTMIKTAR AS BURUTMIKTAR,S.EK3,AR.EK1 ICINDEKILER," +
             "  CONVERT(datetime,CONVERT(NVARCHAR(10),ISNULL(P.TARIH, GETDATE()),102)) TARIH," +
             "  DATEADD(DAY,CONVERT(INT,ISNULL(S.RAFOMRU,1))-1,CONVERT(datetime,CONVERT(NVARCHAR(10),ISNULL(P.TARIH, GETDATE()),102))) SKTARIHI," +
             "  S.RAFOMRU,AR.EK2 ETIKETEK2,AR.EK3 ETIKETEK3,AR.EK4 ETIKETEK4,AR.EK5 ETIKETEK5," +
             "  AR.EK6 ETIKETEK6,AR.EK7 ETIKETEK7,AR.EK8 ETIKETEK8,AR.EK9 ETIKETEK9,AR.EK10 ETIKETEK10 " +
             " FROM STOK S " +
             "    INNER      JOIN ARTETIKETDETAY AR ON AR.STOKID = S.STOKID " +
             "    LEFT OUTER JOIN PARTI_NO_TERAZI P ON  S.STOKID = P.STOKID AND P.PARTINO = @PARTINO " +
             " WHERE S.STOKID=@STOKID ");
     _sqlProvider.AddParameter("STOKID", stokid);
     _sqlProvider.AddParameter("MIKTAR", miktar);
     _sqlProvider.AddParameter("DARA", daramiktar);
     _sqlProvider.AddParameter("BURUTMIKTAR", miktar + daramiktar);
     _sqlProvider.AddParameter("PARTINO", partino);*/


           var dataSet=  api.GetDataSet(PrintBarcode(stokid, partino, miktar, daramiktar),"Execute");
            System.Data.DataTable dTable = dataSet.Tables["datatable1"]; 

 
            var dt = new DataTable();
            //dt.Load(_sqlProvider.ExecuteReader());
            dt = dTable;
            if (dt.Rows.Count != 0)
            {
                DateTime uretimtarihi = Convert.ToDateTime(dt.Rows[0]["TARIH"].ToString());
                DateTime sktarihi = Convert.ToDateTime(dt.Rows[0]["SKTARIHI"].ToString());
                string birim = dt.Rows[0]["BIRIM"].ToString();

                if (!tekrarbasim)
                {
                    ///double GROSSQUANTITY = Convert.ToDouble(dt.Rows[0]["GROSSQUANTITY"].ToString());
                     

                    PartiNoInsert(partino,stokid,miktar,uretimtarihi, uretimtarihi, daramiktar+miktar, daramiktar, DateTime.Now, sktarihi);//dbOperation.PartiNoOlusumuKaydet(partino, stokid, miktar, daramiktar, uretimtarihi, sktarihi, koliicinde, koligrupid);


                    if (UretimTalebiniOtomatikOlustur)
                        dbOperation.UretimTalebiniOlustur(partino, stokid, birim, miktar, uretimtarihi, UretimTalepDepoId);
                }

                if (report1 == null)
                    report1 = new FastReport.Report();

                report1.Refresh();

                string frxDosyaAdi = dt.Rows[0]["EK3"].ToString().ToLower();
                if (frxDosyaAdi == "")
                    frxDosyaAdi = VarsayilanEtiket;

                report1.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Raporlar\\" +
                               frxDosyaAdi.Replace(".frx","") + ".frx");

                report1.RegisterData(dt, "Etiket");
                report1.GetDataSource("Etiket").Enabled = true;

                if (Onizleme)
                {
                    report1.PrintSettings.Copies = 1;
                    
                    report1.PrintSettings.ShowDialog = true;
                    //report1.PrintSettings.Printer = dsRow["Printer"].ToString();
                    report1.Show();
                }
                else
                {
                    
                    /*report1.PrintSettings.ShowDialog = false;
                    report1.PrintSettings.Printer = BarkodPrinterName;
                    report1.Refresh();
                    report1.Print();*/
                }
                report1.Abort();
            }
            else
                MessageBox.Show("Etiket Tasarımı Yapılmamış, MUHASEBEYE Haber Veriniz..");
            etiketsubeadi = "";
        }

        public void PartiNoInsert(string LOTNO, int STOCKID, double QUANTITY, DateTime TDATE, DateTime TTIME, double GROSSQUANTITY,double TARE,DateTime PRODUCTIONDATE,DateTime EXPIRATIONDATE)
        {
            /* _sqlProvider = new SqlProvider("INSERT INTO [PARTI_NO_TERAZI] ([PARTINO],[STOKID],[MIKTAR],[DARA],[BURUTMIKTAR],[URETIMTARIHI],[SONKULLANMATARIHI],[KOLIICINDE],[KOLIGRUPID]) " +
                 " VALUES (@PARTINO,@STOKID,@MIKTAR,@DARA,@BURUTMIKTAR,@URETIMTARIHI,@SONKULLANMATARIHI,@KOLIICINDE,@KOLIGRUPID)", false);
             _sqlProvider.AddParameter("PARTINO", partino);
             _sqlProvider.AddParameter("STOKID", stokid);
             _sqlProvider.AddParameter("MIKTAR", miktar);
             _sqlProvider.AddParameter("DARA", daramiktar);
             _sqlProvider.AddParameter("BURUTMIKTAR", miktar + daramiktar);
             _sqlProvider.AddParameter("URETIMTARIHI", uretimtarihi);
             _sqlProvider.AddParameter("SONKULLANMATARIHI", sktarihi);
             _sqlProvider.AddParameter("KOLIICINDE", koliicinde);
             _sqlProvider.AddParameter("KOLIGRUPID", koligrupid);
             _sqlProvider.ExecuteNonQuery();
             */
            //SP_STOCK_SCALE_TRANS_INSERT

       

            JObject obj = new JObject();
            obj["Action"] = "Execute";
            obj["Object"] = "SP_STOCK_SCALE_TRANS_INSERT";
            obj["LoginToken"] = api.LoginToken;
            
            var Parameters = new JObject();

            Parameters["LOTNO"] = LOTNO.ToString();
            //Parameters["STOCKID"] = STOCKID.ToString();
            Parameters["STOCKFICHEDETAILID"] = STOCKID.ToString();
            Parameters["QUANTITY"] = QUANTITY.ToString();
            Parameters["TDATE"] = TDATE.ToString("yyyy-MM-dd HH:mm:ss");
            Parameters["TTIME"] = TTIME.ToString("HH:mm:ss");
            Parameters["GROSSQUANTITY"] = GROSSQUANTITY.ToString();
            Parameters["TARE"] = TARE.ToString();
            Parameters["PRODUCTIONDATE"] = PRODUCTIONDATE.ToString("yyyy-MM-dd HH:mm:ss");
            Parameters["EXPIRATIONDATE"] = EXPIRATIONDATE.ToString("yyyy-MM-dd HH:mm:ss");
            obj["Parameters"] = Parameters;

            string s = api.post(obj.ToString());
 

        }

        public JObject PrintBarcode(int stokid, string partino, double miktar=0,double daramiktar=0)
        {

           /* var res = api.post(@"{
                ""Action"":""Execute"",
                ""Object"":""SP_STOCK_PRODUCTION_PRINTBARCODE"",
                ""Parameters"":{ ""STOKID"":" + stokid.ToString() +
               @",""MIKTAR"":" + miktar.ToString() +
               @",""DARA"":" + daramiktar.ToString() + @" },
                ""PARTINO"":" + partino +
               @"},
                ""LoginToken"":""" + api.LoginToken + @"""}");*/

            JObject obj = new JObject();
            obj["Action"] = "Execute";
            obj["Object"] = "SP_STOCK_PRODUCTION_PRINTBARCODE";
            obj["LoginToken"] = api.LoginToken;

            var Parameters = new JObject();
           

            //var Parameters1 = new JObject();
            Parameters["STOCKFICHEDETAILID"] = stokid.ToString();
            Parameters["MIKTAR"] = miktar.ToString();
            Parameters["DARA"] = daramiktar.ToString();
            Parameters["PARTINO"] = partino.ToString();
            Parameters["HOTELID"] = "18892";
            obj["Parameters"] = Parameters;

            //Parameters.Add(Parameters1);

           // Parameters = Parameters1;
            return obj;
        }

        public string PartiNoUret(DateTime dt)
        {
            string partiNo = "";
            string s = @"{
                ""LoginToken"" :" + @"""" + api.LoginToken + @""",
                ""Action"": ""Function"",
                ""Object"":""FN_STOCK_PRODUCTION_MAXLOTNO"",
                ""Parameters"": {
                ""HOTELID"" : " + @"""" + 18892.ToString() + @""",
                ""DATE"": "+ @"""" + DateTime.Now.ToString("yyyy-MM-dd") + @"""
                }
            }";
            var Res =  api.post(s);

            if (!Res.Contains("[") || !Res.Contains("]"))
            {
                MessageBox.Show(Res.ToString()+" Object: "+ "FN_STOCK_PRODUCTION_MAXLOTNO", "ElektraWeb", MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw null;
            }

            var obj = JArray.Parse(Res);//JObject.Parse(Res);
            string pNo= obj[0][0]["Return"].ToString();

             
            if (pNo == "")
            {
               
              partiNo = string.Format("{0:ddMMyy}{1}", dt, "3001");
                         
              

                //PartiNoInsert(partiNo, tarih, tableName);

            }
            else
            {
                while (pNo.Length<10)
                {
                    pNo = pNo.Insert(0, "0");
                }
                int parti = Convert.ToInt32(pNo.Substring(6, 4)) + 1;
                partiNo = string.Format("{0:ddMMyy}{1}", dt, parti);
                //PartiNoInsert(partiNo, tarih, tableName);
            }
            return partiNo;
        }

        #region Koli işlemleri 
        private void btnKoliBaslat_Click(object sender, EventArgs e)
        {
            KoliAktif = true;
            KoliAktifeGoreKontrolleri_ve_DegiskenleriSetEt();
            btnKoliBaslat.Visible = false;
        }

        private void btn_Koli_Iptal_Click(object sender, EventArgs e)
        {
            MamulButonlariniCiz(0);
            KoliAktif = false;
            KoliAktifeGoreKontrolleri_ve_DegiskenleriSetEt();
            btnKoliBaslat.Visible = true;
        }

        private void KoliAktifeGoreKontrolleri_ve_DegiskenleriSetEt()
        {
            btn_Koli_Iptal.Visible = KoliAktif;
            btnKoliEtiketiBas.Visible = KoliAktif;
            lblKoliStokAdi.Visible = KoliAktif;
            lblKoliToplami.Visible = KoliAktif;
            koliStokid = 0;
            koliGrupID = 0;
            koliToplami = 0;
            koliIciAdet = 0;
            lblKoliStokAdi.Text = "";
            lblKoliToplami.Text = "Koli Toplamı : 0 ";
        }

        private void btnKoliEtiketiBas_Click(object sender, EventArgs e)
        {
            EtiketBas(koliStokid, koliToplami, 0, false, koliGrupID);
            KoliAktif = false;
            KoliAktifeGoreKontrolleri_ve_DegiskenleriSetEt();
            MamulButonlariniCiz(0);
            btnKoliBaslat.Visible = true;
        }
        #endregion

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            txtMiktar.BackColor = Color.Blue;
        }

        #region Tekrar Etiket Basma metodları
        private void btnTekrarEtiketBasmakIcinBarkodOkut_Click(object sender, EventArgs e)
        {
            lblBakodOkutunuz.Visible = true;
            txtTekrarBarkod.Visible = true;
            btnTekrarEtiketYazdir.Visible = true;
            txtTekrarBarkod.Focus();
            
        }
        
        private void btnTekrarEtiketYazdir_Click(object sender, EventArgs e)
        {
            string partino = txtTekrarBarkod.Text;
            if (partino.Length == 10)
            {
                int stokid = 0;
                double miktar = 0;
                double daramiktar = 0;
                if (dbOperation.TekrarEtiketYazdirilacakKaydiBul(txtTekrarBarkod.Text, ref stokid, ref miktar))
                {
                    EtiketBas(stokid,miktar,daramiktar,false,0,partino);
                }
            }

            lblBakodOkutunuz.Visible = false;
            txtTekrarBarkod.Visible = false;
            btnTekrarEtiketYazdir.Visible = false;

        }
        #endregion

        private void rtbLOG_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MenuRefresh(); 
        }
    }
}
