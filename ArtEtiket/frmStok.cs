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
    public partial class frmStok : Form
    {
        public frmStok()
        {
            InitializeComponent();
        }

        private SqlProvider _sqlProvider;
        private DataTable _dtStok;
        private void frmStok_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                TextBox txt = new TextBox();
                txt.Name = dataGridView1.Columns[i].Name;
                txt.Width = dataGridView1.Columns[i].Width;
                var margin = txt.Margin;
                margin.All = 0;
                txt.Margin = margin;
                txt.Height = 25;
                txt.BackColor = Color.BlanchedAlmond;
                txt.KeyDown += new KeyEventHandler(txt_KeyDown);
                //txt.TextChanged += new EventHandler(txt_TextChanged);
                pnlFilter.Controls.Add(txt);
            }
            StokDoldur();
            dataGridView1.DataSource = _dtStok;
            toolStripStatusLabel1.Text = string.Format("(" + "{0:0}", _dtStok.Rows.Count + ") Kayıt Listelendi");


        }
        public void StokDoldur()
        {
            _sqlProvider = new SqlProvider("SELECT S.STOKID, S.KODU, S.ADI, S.BIRIM, S.EK3 ETIKETTURU ,A.EK1,A.EK2,A.EK3,A.EK4,A.EK5,A.EK6,A.EK7,A.EK8,A.EK9,A.EK10,A.ADET1,A.ADET2,A.ADET3,A.ADET4,A.ADET5,A.ADET6,A.ADET7,A.ADET8,A.ADET9,A.DARA1,A.DARA2,A.DARA3,A.DARA4,A.DARA5,A.DARA6,A.DARA7,A.DARA8,A.DARA9 FROM STOK AS S LEFT OUTER JOIN ARTETIKETDETAY AS A ON A.STOKID = S.STOKID WHERE    KODU LIKE 'S91%' AND HLISTE=1 AND  (ISNULL(S.KKALDIR, 0) = 0) AND (S.TURU = 'Hammadde') ORDER BY S.KODU", false);
            _dtStok = new DataTable();
            _dtStok.Load(_sqlProvider.ExecuteReader());

        }

        private void tSBtnDetay_Click(object sender, EventArgs e)
        {
            int stokId = 0;
            if (dataGridView1.CurrentRow != null)
            {
                stokId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            DataRow[] drStok = _dtStok.Select("STOKID=" + stokId + "");
            DataTable dt = drStok.CopyToDataTable();
            frmStokDetay stokDetay = new frmStokDetay(dt, this);
            stokDetay.Width = this.Width;
            stokDetay.MdiParent = this.MdiParent;
            stokDetay.Show();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int stokId = 0;
            if (dataGridView1.CurrentRow != null)
            {
                stokId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            DataRow[] drStok = _dtStok.Select("STOKID=" + stokId + "");
            DataTable dt = drStok.CopyToDataTable();
            frmStokDetay stokDetay = new frmStokDetay(dt, this);
            stokDetay.Width = this.Width;
            stokDetay.MdiParent = this.MdiParent;
            stokDetay.Show();
        }
 
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

            try
            {
                int index = e.Column.Index;
                TextBox txt = pnlFilter.Controls[index] as TextBox;
                txt.Width = e.Column.Width;
            }
            catch (Exception)
            {

                return;
            }

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StokSearch();
            }
            else if (e.KeyCode == Keys.Back)
            {
                StokSearch();
            }

        }

        string _controlName;
        public void Focuss()
        {
            for (int i = 0; i < pnlFilter.Controls.Count; i++)
            {
                if (pnlFilter.Controls[i].Name==_controlName)
                {
                    pnlFilter.Controls[i].Focus();
                }
            }
        }

        public void StokSearch()
        {  
            try
            {
                string filtre = "";
                string d = "";
                for (int i = 0; i < pnlFilter.Controls.Count; i++)
                {
                    if (pnlFilter.Controls[i].Focused)
                    {
                        filtre = pnlFilter.Controls[i].Name;
                        _controlName = pnlFilter.Controls[i].Name;
                        d = pnlFilter.Controls[i].Text;
                    }
                }
              string f = filtre + " LIKE '" + d + "%'";
                DataRow[] drStok = _dtStok.Select(f);
                DataTable dt = drStok.CopyToDataTable();
                dataGridView1.DataSource = dt;
                toolStripStatusLabel1.Text = string.Format("(" + "{0:0}", dt.Rows.Count + ") Kayıt Listelendi");
            }
            catch (Exception)
            {
                return;
            }
        }

        void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tSBtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   }
}
