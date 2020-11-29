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
    public partial class frmFaturaDetay : Form
    {
        private readonly int _fatid;

        public frmFaturaDetay(int fatid)
        {
            _fatid = fatid;
            InitializeComponent();
        }

        private SqlProvider _sqlProvider;
        private void frmFaturaDetay_Load(object sender, EventArgs e)
        {
            _sqlProvider = new SqlProvider("SELECT S.KODU,ADI,FI.FADET,FBFIYAT,ARATOPLAM  FROM FATISL FI INNER JOIN STOK S ON S.STOKID=FI.STOKID WHERE FATID=@FATID", false);
            _sqlProvider.AddParameter("FATID",_fatid);
            DataTable dtFatIsl=new DataTable();
            dtFatIsl.Load(_sqlProvider.ExecuteReader());
            dataGridView1.DataSource = dtFatIsl;
        }
    }
}
