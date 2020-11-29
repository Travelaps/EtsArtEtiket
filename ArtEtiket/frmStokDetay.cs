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
    public partial class frmStokDetay : Form
    {
        private readonly DataTable _dtStokDetay;
        private readonly frmStok _frm;

        public frmStokDetay(DataTable dtStokDetay, frmStok frm)
        {
            _dtStokDetay = dtStokDetay;
            _frm = frm;
            InitializeComponent();
        }

        private SqlProvider _sqlProvider;
        private void frmStokDetay_Load(object sender, EventArgs e)
        {
            lblStokKodu.Text = Properties.Settings.Default.StokKoduAciklama;
            lblStokAdi.Text = Properties.Settings.Default.StokAdiAciklama;
            lblEk1.Text = Properties.Settings.Default.Ek1Aciklama;
            lblEk2.Text = Properties.Settings.Default.Ek2Aciklama;
            lblEk3.Text = Properties.Settings.Default.Ek3Aciklama;
            lblEk4.Text = Properties.Settings.Default.Ek4Aciklama;
            lblEk5.Text = Properties.Settings.Default.Ek5Aciklama;
            lblEk6.Text = Properties.Settings.Default.Ek6Aciklama;
            lblEk7.Text = Properties.Settings.Default.Ek7Aciklama;
            lblEk8.Text = Properties.Settings.Default.Ek8Aciklama;
            lblEk9.Text = Properties.Settings.Default.Ek9Aciklama;
            lblEk10.Text = Properties.Settings.Default.Ek10Aciklama;

            txtStokKodu.Text = _dtStokDetay.Rows[0]["KODU"].ToString();
            txtStokAdi.Text = _dtStokDetay.Rows[0]["ADI"].ToString();
            txtEk1.Text = _dtStokDetay.Rows[0]["EK1"].ToString();
            txtEk2.Text = _dtStokDetay.Rows[0]["EK2"].ToString();
            txtEk3.Text = _dtStokDetay.Rows[0]["EK3"].ToString();
            txtEk4.Text = _dtStokDetay.Rows[0]["EK4"].ToString();
            txtEk5.Text = _dtStokDetay.Rows[0]["EK5"].ToString();
            txtEk6.Text = _dtStokDetay.Rows[0]["EK6"].ToString();
            txtEk7.Text = _dtStokDetay.Rows[0]["EK7"].ToString();
            txtEk8.Text = _dtStokDetay.Rows[0]["EK8"].ToString();
            txtEk9.Text = _dtStokDetay.Rows[0]["EK9"].ToString();
            txtEk10.Text = _dtStokDetay.Rows[0]["EK10"].ToString();

            txtAdet1.Text = _dtStokDetay.Rows[0]["ADET1"].ToString();
            txtAdet2.Text = _dtStokDetay.Rows[0]["ADET2"].ToString();
            txtAdet3.Text = _dtStokDetay.Rows[0]["ADET3"].ToString();
            txtAdet4.Text = _dtStokDetay.Rows[0]["ADET4"].ToString();
            txtAdet5.Text = _dtStokDetay.Rows[0]["ADET5"].ToString();
            txtAdet6.Text = _dtStokDetay.Rows[0]["ADET6"].ToString();
            txtAdet7.Text = _dtStokDetay.Rows[0]["ADET7"].ToString();
            txtAdet8.Text = _dtStokDetay.Rows[0]["ADET8"].ToString();
            txtAdet9.Text = _dtStokDetay.Rows[0]["ADET9"].ToString();

            txtDara1.Text = _dtStokDetay.Rows[0]["DARA1"].ToString();
            txtDara2.Text = _dtStokDetay.Rows[0]["DARA2"].ToString();
            txtDara3.Text = _dtStokDetay.Rows[0]["DARA3"].ToString();
            txtDara4.Text = _dtStokDetay.Rows[0]["DARA4"].ToString();
            txtDara5.Text = _dtStokDetay.Rows[0]["DARA5"].ToString();
            txtDara6.Text = _dtStokDetay.Rows[0]["DARA6"].ToString();
            txtDara7.Text = _dtStokDetay.Rows[0]["DARA7"].ToString();
            txtDara8.Text = _dtStokDetay.Rows[0]["DARA8"].ToString();
            txtDara9.Text = _dtStokDetay.Rows[0]["DARA9"].ToString();
        }

        private void tSBtnKaydet_Click(object sender, EventArgs e)
        {
            _sqlProvider = new SqlProvider("SELECT COUNT(*) FROM ARTETIKETDETAY WHERE STOKID=@STOKID", false);
            _sqlProvider.AddParameter("STOKID", _dtStokDetay.Rows[0]["STOKID"]);
            bool update = Convert.ToBoolean(_sqlProvider.ExecuteScalar());
            if (update)
            {
                _sqlProvider = new SqlProvider(
                    " UPDATE ARTETIKETDETAY "+
                    " SET "+
                    "   EK1=@EK1, EK2=@EK2 ,EK3=@EK3, EK4=@EK4, EK5=@EK5, EK6=@EK6, EK7=@EK7, EK8=@EK8, EK9=@EK9, EK10=@EK10, "+
                    "   ADET1=@ADET1, ADET2=@ADET2 ,ADET3=@ADET3, ADET4=@ADET4, ADET5=@ADET5, ADET6=@ADET6, ADET7=@ADET7, ADET8=@ADET8, ADET9=@ADET9, " +
                    "   DARA1=@DARA1, DARA2=@DARA2 ,DARA3=@DARA3, DARA4=@DARA4, DARA5=@DARA5, DARA6=@DARA6, DARA7=@DARA7, DARA8=@DARA8, DARA9=@DARA9 " +
                    " WHERE STOKID=@STOKID", false);

                _sqlProvider.AddParameter("STOKID", _dtStokDetay.Rows[0]["STOKID"]);
                _sqlProvider.AddParameter("EK1", txtEk1.Text);
                _sqlProvider.AddParameter("EK2", txtEk2.Text);
                _sqlProvider.AddParameter("EK3", txtEk3.Text);
                _sqlProvider.AddParameter("EK4", txtEk4.Text);
                _sqlProvider.AddParameter("EK5", txtEk5.Text);
                _sqlProvider.AddParameter("EK6", txtEk6.Text);
                _sqlProvider.AddParameter("EK7", txtEk7.Text);
                _sqlProvider.AddParameter("EK8", txtEk8.Text);
                _sqlProvider.AddParameter("EK9", txtEk9.Text);
                _sqlProvider.AddParameter("EK10", txtEk10.Text);
                _sqlProvider.AddParameter("ADET1", txtAdet1.Text);
                _sqlProvider.AddParameter("ADET2", txtAdet2.Text);
                _sqlProvider.AddParameter("ADET3", txtAdet3.Text);
                _sqlProvider.AddParameter("ADET4", txtAdet4.Text);
                _sqlProvider.AddParameter("ADET5", txtAdet5.Text);
                _sqlProvider.AddParameter("ADET6", txtAdet6.Text);
                _sqlProvider.AddParameter("ADET7", txtAdet7.Text);
                _sqlProvider.AddParameter("ADET8", txtAdet8.Text);
                _sqlProvider.AddParameter("ADET9", txtAdet9.Text);
                _sqlProvider.AddParameter("DARA1", txtDara1.Text);
                _sqlProvider.AddParameter("DARA2", txtDara2.Text);
                _sqlProvider.AddParameter("DARA3", txtDara3.Text);
                _sqlProvider.AddParameter("DARA4", txtDara4.Text);
                _sqlProvider.AddParameter("DARA5", txtDara5.Text);
                _sqlProvider.AddParameter("DARA6", txtDara6.Text);
                _sqlProvider.AddParameter("DARA7", txtDara7.Text);
                _sqlProvider.AddParameter("DARA8", txtDara8.Text);
                _sqlProvider.AddParameter("DARA9", txtDara9.Text);
                _sqlProvider.ExecuteNonQuery();
            }
            else
            {
                _sqlProvider = new SqlProvider("INSERT INTO ARTETIKETDETAY (STOKID,EK1,EK2,EK3,EK4,EK5,EK6,EK7,EK8,EK9,EK10,ADET1,ADET2,ADET3,ADET4,ADET5,ADET6,ADET7,ADET8,ADET9,DARA1,DARA2,DARA3,DARA4,DARA5,DARA6,DARA7,DARA8,DARA9) VALUES (@STOKID,@EK1,@EK2,@EK3,@EK4,@EK5,@EK6,@EK7,@EK8,@EK9,@EK10,@ADET1,@ADET2,@ADET3,@ADET4,@ADET5,@ADET6,@ADET7,@ADET8,@ADET9,@DARA1,@DARA2,@DARA3,@DARA4,@DARA5,@DARA6,@DARA7,@DARA8,@DARA9)", false);

                _sqlProvider.AddParameter("STOKID", _dtStokDetay.Rows[0]["STOKID"]);
                _sqlProvider.AddParameter("EK1", txtEk1.Text);
                _sqlProvider.AddParameter("EK2", txtEk2.Text);
                _sqlProvider.AddParameter("EK3", txtEk3.Text);
                _sqlProvider.AddParameter("EK4", txtEk4.Text);
                _sqlProvider.AddParameter("EK5", txtEk5.Text);
                _sqlProvider.AddParameter("EK6", txtEk6.Text);
                _sqlProvider.AddParameter("EK7", txtEk7.Text);
                _sqlProvider.AddParameter("EK8", txtEk8.Text);
                _sqlProvider.AddParameter("EK9", txtEk9.Text);
                _sqlProvider.AddParameter("EK10", txtEk10.Text);
                _sqlProvider.AddParameter("ADET1", txtAdet1.Text);
                _sqlProvider.AddParameter("ADET2", txtAdet2.Text);
                _sqlProvider.AddParameter("ADET3", txtAdet3.Text);
                _sqlProvider.AddParameter("ADET4", txtAdet4.Text);
                _sqlProvider.AddParameter("ADET5", txtAdet5.Text);
                _sqlProvider.AddParameter("ADET6", txtAdet6.Text);
                _sqlProvider.AddParameter("ADET7", txtAdet7.Text);
                _sqlProvider.AddParameter("ADET8", txtAdet8.Text);
                _sqlProvider.AddParameter("ADET9", txtAdet9.Text);
                _sqlProvider.AddParameter("DARA1", txtDara1.Text);
                _sqlProvider.AddParameter("DARA2", txtDara2.Text);
                _sqlProvider.AddParameter("DARA3", txtDara3.Text);
                _sqlProvider.AddParameter("DARA4", txtDara4.Text);
                _sqlProvider.AddParameter("DARA5", txtDara5.Text);
                _sqlProvider.AddParameter("DARA6", txtDara6.Text);
                _sqlProvider.AddParameter("DARA7", txtDara7.Text);
                _sqlProvider.AddParameter("DARA8", txtDara8.Text);
                _sqlProvider.AddParameter("DARA9", txtDara9.Text);
                _sqlProvider.ExecuteNonQuery();
            }
            

            //int index = Convert.ToInt32(_frm.dataGridView1.CurrentRow.Index);
            _frm.StokDoldur();
            _frm.Focuss();
            _frm.StokSearch();
            Close();
            //_frm.dataGridView1.Rows[index].Selected = true;
            //_frm.dataGridView1.FirstDisplayedScrollingRowIndex = index;
            //_frm.dataGridView1.Refresh();

        }

        private void tSBtnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void label3_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk1); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk2); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk3); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk4); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label7_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk5); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label8_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk6); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk7); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label10_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk8); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label11_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk9);
            label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
            frmLabel label = new frmLabel(this, lblEk10); label.StartPosition = FormStartPosition.CenterScreen;
            label.ShowDialog();
        }
    }
}
