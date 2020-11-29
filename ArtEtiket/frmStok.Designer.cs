namespace ArtEtiket
{
    partial class frmStok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStok));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSBtnDetay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSBtnKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.araçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSBtnKapat = new System.Windows.Forms.ToolStripButton();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STOKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KODU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETIKETTURU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EK10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBtnDetay,
            this.toolStripSeparator1,
            this.tSBtnKaydet,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.tSBtnKapat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSBtnDetay
            // 
            this.tSBtnDetay.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnDetay.Image")));
            this.tSBtnDetay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnDetay.Name = "tSBtnDetay";
            this.tSBtnDetay.Size = new System.Drawing.Size(62, 22);
            this.tSBtnDetay.Text = "Detay";
            this.tSBtnDetay.Click += new System.EventHandler(this.tSBtnDetay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tSBtnKaydet
            // 
            this.tSBtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnKaydet.Image")));
            this.tSBtnKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnKaydet.Name = "tSBtnKaydet";
            this.tSBtnKaydet.Size = new System.Drawing.Size(69, 22);
            this.tSBtnKaydet.Text = "Kaydet";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.araçlarToolStripMenuItem});
            this.toolStripDropDownButton1.Enabled = false;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "Araçlar";
            // 
            // araçlarToolStripMenuItem
            // 
            this.araçlarToolStripMenuItem.Name = "araçlarToolStripMenuItem";
            this.araçlarToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.araçlarToolStripMenuItem.Text = "Kolon Tasarımını Kaydet";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tSBtnKapat
            // 
            this.tSBtnKapat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnKapat.Name = "tSBtnKapat";
            this.tSBtnKapat.Size = new System.Drawing.Size(46, 22);
            this.tSBtnKapat.Text = "Kapat";
            this.tSBtnKapat.Click += new System.EventHandler(this.tSBtnKapat_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 25);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(784, 26);
            this.pnlFilter.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STOKID,
            this.KODU,
            this.ADI,
            this.ETIKETTURU,
            this.EK1,
            this.EK2,
            this.EK3,
            this.EK4,
            this.EK5,
            this.EK6,
            this.EK7,
            this.EK8,
            this.EK9,
            this.EK10});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 51);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(784, 668);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            // 
            // STOKID
            // 
            this.STOKID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.STOKID.DataPropertyName = "STOKID";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.STOKID.DefaultCellStyle = dataGridViewCellStyle2;
            this.STOKID.HeaderText = "Stokid";
            this.STOKID.Name = "STOKID";
            this.STOKID.ReadOnly = true;
            this.STOKID.Width = 68;
            // 
            // KODU
            // 
            this.KODU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.KODU.DataPropertyName = "KODU";
            this.KODU.HeaderText = "Kodu";
            this.KODU.Name = "KODU";
            this.KODU.ReadOnly = true;
            this.KODU.Width = 56;
            // 
            // ADI
            // 
            this.ADI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ADI.DataPropertyName = "ADI";
            this.ADI.HeaderText = "Adı";
            this.ADI.Name = "ADI";
            this.ADI.ReadOnly = true;
            this.ADI.Width = 200;
            // 
            // ETIKETTURU
            // 
            this.ETIKETTURU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ETIKETTURU.DataPropertyName = "ETIKETTURU";
            this.ETIKETTURU.HeaderText = "E. Türü";
            this.ETIKETTURU.Name = "ETIKETTURU";
            this.ETIKETTURU.ReadOnly = true;
            this.ETIKETTURU.Width = 74;
            // 
            // EK1
            // 
            this.EK1.DataPropertyName = "EK1";
            this.EK1.HeaderText = "Ek1";
            this.EK1.Name = "EK1";
            this.EK1.ReadOnly = true;
            // 
            // EK2
            // 
            this.EK2.DataPropertyName = "EK2";
            this.EK2.HeaderText = "Ek2";
            this.EK2.Name = "EK2";
            this.EK2.ReadOnly = true;
            // 
            // EK3
            // 
            this.EK3.DataPropertyName = "EK3";
            this.EK3.HeaderText = "Ek3";
            this.EK3.Name = "EK3";
            this.EK3.ReadOnly = true;
            // 
            // EK4
            // 
            this.EK4.DataPropertyName = "EK4";
            this.EK4.HeaderText = "Ek4";
            this.EK4.Name = "EK4";
            this.EK4.ReadOnly = true;
            // 
            // EK5
            // 
            this.EK5.DataPropertyName = "EK5";
            this.EK5.HeaderText = "Ek5";
            this.EK5.Name = "EK5";
            this.EK5.ReadOnly = true;
            // 
            // EK6
            // 
            this.EK6.DataPropertyName = "EK6";
            this.EK6.HeaderText = "Ek6";
            this.EK6.Name = "EK6";
            this.EK6.ReadOnly = true;
            // 
            // EK7
            // 
            this.EK7.DataPropertyName = "EK7";
            this.EK7.HeaderText = "Ek7";
            this.EK7.Name = "EK7";
            this.EK7.ReadOnly = true;
            this.EK7.Width = 75;
            // 
            // EK8
            // 
            this.EK8.DataPropertyName = "EK8";
            this.EK8.HeaderText = "Ek8";
            this.EK8.Name = "EK8";
            this.EK8.ReadOnly = true;
            this.EK8.Width = 75;
            // 
            // EK9
            // 
            this.EK9.DataPropertyName = "EK9";
            this.EK9.HeaderText = "Ek9";
            this.EK9.Name = "EK9";
            this.EK9.ReadOnly = true;
            this.EK9.Width = 75;
            // 
            // EK10
            // 
            this.EK10.DataPropertyName = "EK10";
            this.EK10.HeaderText = "Ek10";
            this.EK10.Name = "EK10";
            this.EK10.ReadOnly = true;
            this.EK10.Width = 75;
            // 
            // frmStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 741);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStok";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Stok";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStok_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSBtnDetay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSBtnKaydet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSBtnKapat;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem araçlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KODU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETIKETTURU;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK3;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK4;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK5;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK6;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK7;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK8;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK9;
        private System.Windows.Forms.DataGridViewTextBoxColumn EK10;
    }
}