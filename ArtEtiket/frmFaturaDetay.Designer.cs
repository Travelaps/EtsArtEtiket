namespace ArtEtiket
{
    partial class frmFaturaDetay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AraToplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SKodu,
            this.SAdi,
            this.FMiktar,
            this.BFiyat,
            this.AraToplam});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(481, 372);
            this.dataGridView1.TabIndex = 0;
            // 
            // SKodu
            // 
            this.SKodu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SKodu.DataPropertyName = "KODU";
            this.SKodu.HeaderText = "Stok Kodu";
            this.SKodu.Name = "SKodu";
            this.SKodu.ReadOnly = true;
            this.SKodu.Width = 82;
            // 
            // SAdi
            // 
            this.SAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SAdi.DataPropertyName = "ADI";
            this.SAdi.HeaderText = "Stok Adi";
            this.SAdi.Name = "SAdi";
            this.SAdi.ReadOnly = true;
            this.SAdi.Width = 72;
            // 
            // FMiktar
            // 
            this.FMiktar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FMiktar.DataPropertyName = "FADET";
            this.FMiktar.HeaderText = "Fatura Miktarı";
            this.FMiktar.Name = "FMiktar";
            this.FMiktar.ReadOnly = true;
            this.FMiktar.Width = 96;
            // 
            // BFiyat
            // 
            this.BFiyat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BFiyat.DataPropertyName = "FBFIYAT";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.BFiyat.DefaultCellStyle = dataGridViewCellStyle5;
            this.BFiyat.HeaderText = "Birim Fiyat";
            this.BFiyat.Name = "BFiyat";
            this.BFiyat.ReadOnly = true;
            this.BFiyat.Width = 79;
            // 
            // AraToplam
            // 
            this.AraToplam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AraToplam.DataPropertyName = "ARATOPLAM";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.AraToplam.DefaultCellStyle = dataGridViewCellStyle6;
            this.AraToplam.HeaderText = "Ara Toplam";
            this.AraToplam.Name = "AraToplam";
            this.AraToplam.ReadOnly = true;
            this.AraToplam.Width = 86;
            // 
            // frmFaturaDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 396);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmFaturaDetay";
            this.Text = "frmFaturaDetay";
            this.Load += new System.EventHandler(this.frmFaturaDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn FMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn AraToplam;
    }
}