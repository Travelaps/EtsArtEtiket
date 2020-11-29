using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArtEtiket
{
    public partial class frmMain : Form
    {
        private SqlConControl _sqlConControl;
        private SqlProvider _sqlProvider;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //check database connectivity
           /* _sqlConControl = new SqlConControl();
            if (!_sqlConControl.ConnectionControl())
            {
                frmConnections connections = new frmConnections();
                connections.ShowDialog();
            }*/

            //set initial parameters
           /* _sqlProvider = new SqlProvider("SELECT COUNT(*) FROM CONFIG WHERE KEYNAME LIKE 'Hammadde Tuketim Depo ID'");
            int value = Convert.ToInt32(_sqlProvider.ExecuteScalar());
            if (value == 0)
            {
                _sqlProvider = new SqlProvider("INSERT INTO CONFIG (PROGNAME,SECTIONSTR,KEYNAME,VALUESTR,[TYPES]) VALUES ('ETSvOzel','Hammadde Parçalama','Hammadde Tuketim Depo ID',1,0)");
                _sqlProvider.ExecuteNonQuery();
            }*/
        }

        private Form CheckMDIFormIsOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    return frm;
                }
            }
            return null;
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            Form f = CheckMDIFormIsOpened("frmStok");
            if (f == null)
            {
                f = new frmStok();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            else
            f.BringToFront();
            //frmStok stok = new frmStok();
            //stok.MdiParent = this;
            //stok.WindowState = FormWindowState.Maximized;
            //stok.Show();
        }

        private void btnParcalama_Click(object sender, EventArgs e)
        {
            Form f = CheckMDIFormIsOpened("frmParcalama");
            if (f == null)
            {
                f = new frmParcalama();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            else
                f.BringToFront();

            //frmParcalama parcalama = new frmParcalama();
            //parcalama.MdiParent = this;
            //parcalama.WindowState = FormWindowState.Maximized;
            //parcalama.Show();
        }

        private void btnUretim_Click(object sender, EventArgs e)
        {
            Form f = CheckMDIFormIsOpened("frmUretim");
            if (f == null)
            {
                MenuBar.Visible = false;
                f = new frmUretim();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            else
                f.BringToFront();

            //frmUretim uretim = new frmUretim();
            //uretim.MdiParent = this;
            //uretim.WindowState = FormWindowState.Maximized;
            //uretim.Show();
        }

        private void mnuServerBaglantisi_Click(object sender, EventArgs e)
        {
            frmConnections connections = new frmConnections();
            connections.ShowDialog();
        }
    }
}
