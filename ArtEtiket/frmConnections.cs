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
    public partial class frmConnections : Form
    {
        public string sqlConStr;
        public frmConnections()
        {
            InitializeComponent();
        }

        private void frmConnections_Load(object sender, EventArgs e)
        {
            //textBox1.Text = Properties.Settings.Default.Serversil;
            //textBox2.Text = Properties.Settings.Default.Login;
            //textBox3.Text = Properties.Settings.Default.Password;
            //textBox4.Text = Properties.Settings.Default.Database;
        }

        private SqlConControl _sqlConControl;
        private void btnTest_Click(object sender, EventArgs e)
        {
            _sqlConControl = new SqlConControl();

            sqlConStr = "SERVER=" + textBox1.Text + "; DATABASE=" + textBox4.Text + "; UID=" + textBox2.Text + "; PWD=" + textBox3.Text;
            if (_sqlConControl.ConnectionControl(sqlConStr))
            {
                picOnline.Visible = true;
                picOffline.Visible = false;
                MessageBox.Show("Bağlantı Kuruldu.");
            }
            else
            {
                picOnline.Visible = false;
                picOffline.Visible = true;
                MessageBox.Show("Bağlantı Kurulamıyor.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Server = textBox1.Text;
            //Properties.Settings.Default.Login = textBox2.Text;
            //Properties.Settings.Default.Password = textBox3.Text;
            //Properties.Settings.Default.Database = textBox4.Text;
            //Properties.Settings.Default.SqlConStr = sqlConStr;
            //Properties.Settings.Default.Save();

            MessageBox.Show("Bağlantı Ayarları Kaydedildi");
        }

    }
}
