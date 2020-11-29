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
    public partial class frmLabel : Form
    {
        private readonly frmStokDetay _frmStokDetay;
        private readonly Label _lbl;

        public frmLabel(frmStokDetay frmStokDetay, Label lbl)
        {
            _frmStokDetay = frmStokDetay;
            _lbl = lbl;
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //switch (_lbl.Name)
            //{
            //    case "lblEk1":
            //        Properties.Settings.Default.Ek1Aciklama = textBox1.Text;
            //        _frmStokDetay.lblStokKodu.Text = textBox1.Text;
            //        Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk2":
            //        Properties.Settings.Default.Ek2Aciklama = textBox1.Text;
            //        _frmStokDetay.lblStokAdi.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk3":
            //        Properties.Settings.Default.Ek3Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk1.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk4":
            //        Properties.Settings.Default.Ek4Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk2.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk5":
            //        Properties.Settings.Default.Ek5Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk3.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk6":
            //        Properties.Settings.Default.Ek6Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk4.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk7":
            //        Properties.Settings.Default.Ek7Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk5.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk8":
            //        Properties.Settings.Default.Ek8Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk6.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk9":
            //        Properties.Settings.Default.Ek9Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk7.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblEk10":
            //        Properties.Settings.Default.Ek10Aciklama = textBox1.Text;
            //        _frmStokDetay.lblEk8.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblStokKodu":
            //        Properties.Settings.Default.StokKoduAciklama = textBox1.Text;
            //        _frmStokDetay.lblEk9.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;
            //    case "lblStokAdi":
            //        Properties.Settings.Default.StokAdiAciklama = textBox1.Text;
            //        _frmStokDetay.lblEk10.Text = textBox1.Text;Properties.Settings.Default.Save();
            //        break;

            //}
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
