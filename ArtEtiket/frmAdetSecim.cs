using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArtEtiket
{
    public partial class frmAdetSecim : Form
    {
        List<MODEL.AdetSecimleri> _list;
        public int _secilenAdet;

        //eğer ADETN içinde -88 olan varsa o zaman Tepsi seçildiğinde kaç adet diye soracağız
        private bool _tepsiAdediSor = false;
        public int _tepsiAdedi = 1;
        public bool _tepsiSecildi = false;

        public string _lblAdet;

        public frmAdetSecim(List<MODEL.AdetSecimleri> list)
        {
            InitializeComponent();
            _list = list;
            _lblAdet = "";
            this.Load += new EventHandler(frmAdetSecim_Load);
        }

        private void frmAdetSecim_Load(object sender, EventArgs e)
        {
            pnlAdetler.Visible = false;
            AdetSecimi_ButonlariniCiz();
            //if (!pnlAdetler.Visible)
            //    Height = 240;
        }


        public void AdetSecimi_ButonlariniCiz()
        {
            #region 1.adım >> Butonlar Halinde Göster
            //Once varolan butonları silelim
            pnlButtons.Controls.Clear();

            // Üretimi yapılan Mamul Grupları: S91 ile başlayanlar
            // Bu mamul gruplarını Altta Butonlar olarak gösterelim , seçip ilgili Mamulleri ekrana getireceğiz
            int i = 0;
            foreach (var l in _list)
            {
                if (l.Adet == -99)
                    pnlAdetler.Visible = true;
                else
                if (l.Adet == -88)
                    _tepsiAdediSor = true;
                else
                {
                    if (l.Adet > 0)
                    {
                        var btn = new Button
                        {
                            Left = i * ((pnlButtons.Width / _list.Count)) + 5,
                            Height = pnlButtons.Height - 10,
                            Width = (pnlButtons.Width / _list.Count) - 10,
                            Tag = l.Adet,
                            Text = l.Aciklama + Environment.NewLine + Environment.NewLine + l.Adet.ToString() + ((l.Tur == "QUANTITY") ? " Adet " : (l.Tur == "LT") ? " LT " : " GR")
                        };
                        btn.Font = new Font(btn.Font.FontFamily, 18);
                        i++;
                        btn.Click += new EventHandler(btn_AdetSecimiClick);
                        pnlButtons.Controls.Add(btn);
                    }
                }
            }

            #endregion
        }
        void btn_AdetSecimiClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            _secilenAdet = Convert.ToInt32(btn.Tag.ToString());
            if (_tepsiAdediSor)
            {
                _tepsiSecildi = true;
                foreach (var c in pnlButtons.Controls)
                {
                    if (c is Button)
                        ((Button)c).Visible = false;
                } 

                lblTespsiAdediGirinizMesaji.Text = _secilenAdet.ToString() + " adetlik tepsiden kaç tepsi ürettiğinizi giriniz. Eğer 1 adet ise direk TAMAM a basınız.";
                _lblAdet = "1";
                AdetGoster();
            }
            else
                Close();
        }

        private void btnRakam_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            _lblAdet = _lblAdet + btn.Text;
            AdetGoster();
        }

        private void AdetGoster()
        {
            if (_lblAdet == "0")
                _lblAdet = "";

            lblAdet.Text = _lblAdet.ToString();
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (_lblAdet.Length > 0)
                _lblAdet = _lblAdet.Substring(0, _lblAdet.Length - 1);
            AdetGoster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _lblAdet = "";
            AdetGoster();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_lblAdet != "")
            {
                if (_tepsiSecildi)
                {
                    _tepsiAdedi = Convert.ToInt32(lblAdet.Text);
                    _tepsiSecildi = false;
                }
                else
                    _secilenAdet = Convert.ToInt32(lblAdet.Text);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _secilenAdet = -999;
            Close();
        }
    }
}
