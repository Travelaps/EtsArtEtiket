namespace ArtEtiket
{
    partial class frmUretim
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
            this.components = new System.ComponentModel.Container();
            this.pnlMamuller = new System.Windows.Forms.FlowLayoutPanel();
            this.rtbLOG = new System.Windows.Forms.RichTextBox();
            this.boxLeftPart = new System.Windows.Forms.GroupBox();
            this.pnlMamulGruplari = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSubeler = new System.Windows.Forms.FlowLayoutPanel();
            this.boxMiktar = new System.Windows.Forms.GroupBox();
            this.pnlMiktar = new System.Windows.Forms.FlowLayoutPanel();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.rtbOkunan = new System.Windows.Forms.RichTextBox();
            this.boxEtiketler = new System.Windows.Forms.GroupBox();
            this.pnlEtiketler = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKoliIslem = new System.Windows.Forms.Panel();
            this.btnKoliEtiketiBas = new System.Windows.Forms.Button();
            this.btn_Koli_Iptal = new System.Windows.Forms.Button();
            this.btnKoliBaslat = new System.Windows.Forms.Button();
            this.lblKoliToplami = new System.Windows.Forms.Label();
            this.lblKoliStokAdi = new System.Windows.Forms.Label();
            this.pnlTekrarEtiketBas = new System.Windows.Forms.Panel();
            this.btnTekrarEtiketYazdir = new System.Windows.Forms.Button();
            this.lblBakodOkutunuz = new System.Windows.Forms.Label();
            this.txtTekrarBarkod = new System.Windows.Forms.TextBox();
            this.btnTekrarEtiketBasmakIcinBarkodOkut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlMamuller.SuspendLayout();
            this.boxLeftPart.SuspendLayout();
            this.boxMiktar.SuspendLayout();
            this.pnlMiktar.SuspendLayout();
            this.boxEtiketler.SuspendLayout();
            this.pnlEtiketler.SuspendLayout();
            this.pnlKoliIslem.SuspendLayout();
            this.pnlTekrarEtiketBas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMamuller
            // 
            this.pnlMamuller.AutoScroll = true;
            this.pnlMamuller.Controls.Add(this.rtbLOG);
            this.pnlMamuller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMamuller.Location = new System.Drawing.Point(3, 19);
            this.pnlMamuller.Name = "pnlMamuller";
            this.pnlMamuller.Size = new System.Drawing.Size(676, 551);
            this.pnlMamuller.TabIndex = 1;
            // 
            // rtbLOG
            // 
            this.rtbLOG.Location = new System.Drawing.Point(3, 3);
            this.rtbLOG.Name = "rtbLOG";
            this.rtbLOG.Size = new System.Drawing.Size(356, 202);
            this.rtbLOG.TabIndex = 0;
            this.rtbLOG.Text = "";
            this.rtbLOG.TextChanged += new System.EventHandler(this.rtbLOG_TextChanged);
            // 
            // boxLeftPart
            // 
            this.boxLeftPart.Controls.Add(this.pnlMamuller);
            this.boxLeftPart.Controls.Add(this.pnlMamulGruplari);
            this.boxLeftPart.Controls.Add(this.pnlSubeler);
            this.boxLeftPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxLeftPart.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.boxLeftPart.Location = new System.Drawing.Point(0, 0);
            this.boxLeftPart.Name = "boxLeftPart";
            this.boxLeftPart.Size = new System.Drawing.Size(682, 729);
            this.boxLeftPart.TabIndex = 3;
            this.boxLeftPart.TabStop = false;
            this.boxLeftPart.Text = "Etiket basılacak ÜRÜNÜ Listeden Seçiniz";
            // 
            // pnlMamulGruplari
            // 
            this.pnlMamulGruplari.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMamulGruplari.Location = new System.Drawing.Point(3, 570);
            this.pnlMamulGruplari.Name = "pnlMamulGruplari";
            this.pnlMamulGruplari.Size = new System.Drawing.Size(676, 84);
            this.pnlMamulGruplari.TabIndex = 5;
            // 
            // pnlSubeler
            // 
            this.pnlSubeler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSubeler.Location = new System.Drawing.Point(3, 654);
            this.pnlSubeler.Name = "pnlSubeler";
            this.pnlSubeler.Size = new System.Drawing.Size(676, 72);
            this.pnlSubeler.TabIndex = 2;
            // 
            // boxMiktar
            // 
            this.boxMiktar.Controls.Add(this.pnlMiktar);
            this.boxMiktar.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxMiktar.Location = new System.Drawing.Point(0, 0);
            this.boxMiktar.Name = "boxMiktar";
            this.boxMiktar.Size = new System.Drawing.Size(322, 226);
            this.boxMiktar.TabIndex = 4;
            this.boxMiktar.TabStop = false;
            this.boxMiktar.Text = "Teraziden Gelen MİKTAR bilgisi SABİTLENMELİDİR !!!";
            // 
            // pnlMiktar
            // 
            this.pnlMiktar.Controls.Add(this.txtMiktar);
            this.pnlMiktar.Controls.Add(this.rtbOkunan);
            this.pnlMiktar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiktar.Location = new System.Drawing.Point(3, 16);
            this.pnlMiktar.Margin = new System.Windows.Forms.Padding(5);
            this.pnlMiktar.Name = "pnlMiktar";
            this.pnlMiktar.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMiktar.Size = new System.Drawing.Size(316, 207);
            this.pnlMiktar.TabIndex = 1;
            // 
            // txtMiktar
            // 
            this.txtMiktar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMiktar.Location = new System.Drawing.Point(8, 8);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(493, 98);
            this.txtMiktar.TabIndex = 0;
            this.txtMiktar.Text = "15.05";
            this.txtMiktar.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // rtbOkunan
            // 
            this.rtbOkunan.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbOkunan.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbOkunan.Enabled = false;
            this.rtbOkunan.Location = new System.Drawing.Point(8, 112);
            this.rtbOkunan.Name = "rtbOkunan";
            this.rtbOkunan.Size = new System.Drawing.Size(299, 88);
            this.rtbOkunan.TabIndex = 1;
            this.rtbOkunan.Text = "";
            // 
            // boxEtiketler
            // 
            this.boxEtiketler.Controls.Add(this.pnlEtiketler);
            this.boxEtiketler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxEtiketler.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxEtiketler.Location = new System.Drawing.Point(0, 226);
            this.boxEtiketler.Name = "boxEtiketler";
            this.boxEtiketler.Size = new System.Drawing.Size(322, 503);
            this.boxEtiketler.TabIndex = 6;
            this.boxEtiketler.TabStop = false;
            this.boxEtiketler.Text = "Kolileme İşlemleri";
            // 
            // pnlEtiketler
            // 
            this.pnlEtiketler.Controls.Add(this.pnlKoliIslem);
            this.pnlEtiketler.Controls.Add(this.pnlTekrarEtiketBas);
            this.pnlEtiketler.Controls.Add(this.panel1);
            this.pnlEtiketler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEtiketler.Location = new System.Drawing.Point(3, 16);
            this.pnlEtiketler.Margin = new System.Windows.Forms.Padding(5);
            this.pnlEtiketler.Name = "pnlEtiketler";
            this.pnlEtiketler.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEtiketler.Size = new System.Drawing.Size(316, 484);
            this.pnlEtiketler.TabIndex = 2;
            // 
            // pnlKoliIslem
            // 
            this.pnlKoliIslem.Controls.Add(this.btnKoliEtiketiBas);
            this.pnlKoliIslem.Controls.Add(this.btn_Koli_Iptal);
            this.pnlKoliIslem.Controls.Add(this.btnKoliBaslat);
            this.pnlKoliIslem.Controls.Add(this.lblKoliToplami);
            this.pnlKoliIslem.Controls.Add(this.lblKoliStokAdi);
            this.pnlKoliIslem.Location = new System.Drawing.Point(8, 8);
            this.pnlKoliIslem.Name = "pnlKoliIslem";
            this.pnlKoliIslem.Size = new System.Drawing.Size(299, 257);
            this.pnlKoliIslem.TabIndex = 4;
            // 
            // btnKoliEtiketiBas
            // 
            this.btnKoliEtiketiBas.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnKoliEtiketiBas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKoliEtiketiBas.ForeColor = System.Drawing.Color.White;
            this.btnKoliEtiketiBas.Location = new System.Drawing.Point(3, 184);
            this.btnKoliEtiketiBas.Name = "btnKoliEtiketiBas";
            this.btnKoliEtiketiBas.Size = new System.Drawing.Size(176, 71);
            this.btnKoliEtiketiBas.TabIndex = 6;
            this.btnKoliEtiketiBas.Text = "Koli Etiketi Bas";
            this.btnKoliEtiketiBas.UseVisualStyleBackColor = false;
            this.btnKoliEtiketiBas.Visible = false;
            this.btnKoliEtiketiBas.Click += new System.EventHandler(this.btnKoliEtiketiBas_Click);
            // 
            // btn_Koli_Iptal
            // 
            this.btn_Koli_Iptal.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Koli_Iptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Koli_Iptal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Koli_Iptal.Location = new System.Drawing.Point(179, 184);
            this.btn_Koli_Iptal.Name = "btn_Koli_Iptal";
            this.btn_Koli_Iptal.Size = new System.Drawing.Size(117, 71);
            this.btn_Koli_Iptal.TabIndex = 1;
            this.btn_Koli_Iptal.Text = "Koli İPTAL";
            this.btn_Koli_Iptal.UseVisualStyleBackColor = false;
            this.btn_Koli_Iptal.Visible = false;
            this.btn_Koli_Iptal.Click += new System.EventHandler(this.btn_Koli_Iptal_Click);
            // 
            // btnKoliBaslat
            // 
            this.btnKoliBaslat.BackColor = System.Drawing.Color.ForestGreen;
            this.btnKoliBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKoliBaslat.ForeColor = System.Drawing.Color.White;
            this.btnKoliBaslat.Location = new System.Drawing.Point(3, 3);
            this.btnKoliBaslat.Name = "btnKoliBaslat";
            this.btnKoliBaslat.Size = new System.Drawing.Size(293, 71);
            this.btnKoliBaslat.TabIndex = 0;
            this.btnKoliBaslat.Text = "Koli Başlat";
            this.btnKoliBaslat.UseVisualStyleBackColor = false;
            this.btnKoliBaslat.Click += new System.EventHandler(this.btnKoliBaslat_Click);
            // 
            // lblKoliToplami
            // 
            this.lblKoliToplami.AutoSize = true;
            this.lblKoliToplami.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKoliToplami.Location = new System.Drawing.Point(65, 157);
            this.lblKoliToplami.Name = "lblKoliToplami";
            this.lblKoliToplami.Size = new System.Drawing.Size(159, 24);
            this.lblKoliToplami.TabIndex = 5;
            this.lblKoliToplami.Text = "Koli Toplamı : 100";
            this.lblKoliToplami.Visible = false;
            // 
            // lblKoliStokAdi
            // 
            this.lblKoliStokAdi.AutoSize = true;
            this.lblKoliStokAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKoliStokAdi.Location = new System.Drawing.Point(19, 77);
            this.lblKoliStokAdi.Name = "lblKoliStokAdi";
            this.lblKoliStokAdi.Size = new System.Drawing.Size(173, 80);
            this.lblKoliStokAdi.TabIndex = 4;
            this.lblKoliStokAdi.Text = "Koli İçindeki Malzeme\r\nMalzeme 1 okunan : 10\r\nMalzeme 1 okunan : 40\r\nMalzeme 1 ok" +
    "unan : 50";
            this.lblKoliStokAdi.Visible = false;
            // 
            // pnlTekrarEtiketBas
            // 
            this.pnlTekrarEtiketBas.Controls.Add(this.btnTekrarEtiketYazdir);
            this.pnlTekrarEtiketBas.Controls.Add(this.lblBakodOkutunuz);
            this.pnlTekrarEtiketBas.Controls.Add(this.txtTekrarBarkod);
            this.pnlTekrarEtiketBas.Controls.Add(this.btnTekrarEtiketBasmakIcinBarkodOkut);
            this.pnlTekrarEtiketBas.Location = new System.Drawing.Point(8, 271);
            this.pnlTekrarEtiketBas.Name = "pnlTekrarEtiketBas";
            this.pnlTekrarEtiketBas.Size = new System.Drawing.Size(299, 132);
            this.pnlTekrarEtiketBas.TabIndex = 5;
            // 
            // btnTekrarEtiketYazdir
            // 
            this.btnTekrarEtiketYazdir.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTekrarEtiketYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTekrarEtiketYazdir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTekrarEtiketYazdir.Location = new System.Drawing.Point(185, 57);
            this.btnTekrarEtiketYazdir.Name = "btnTekrarEtiketYazdir";
            this.btnTekrarEtiketYazdir.Size = new System.Drawing.Size(111, 70);
            this.btnTekrarEtiketYazdir.TabIndex = 10;
            this.btnTekrarEtiketYazdir.Text = "Etiket Bas";
            this.btnTekrarEtiketYazdir.UseVisualStyleBackColor = false;
            this.btnTekrarEtiketYazdir.Visible = false;
            this.btnTekrarEtiketYazdir.Click += new System.EventHandler(this.btnTekrarEtiketYazdir_Click);
            // 
            // lblBakodOkutunuz
            // 
            this.lblBakodOkutunuz.AutoSize = true;
            this.lblBakodOkutunuz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakodOkutunuz.Location = new System.Drawing.Point(30, 57);
            this.lblBakodOkutunuz.Name = "lblBakodOkutunuz";
            this.lblBakodOkutunuz.Size = new System.Drawing.Size(137, 32);
            this.lblBakodOkutunuz.TabIndex = 9;
            this.lblBakodOkutunuz.Text = "Etiketin Üzerindeki\r\nBarkodu Okutunuz";
            this.lblBakodOkutunuz.Visible = false;
            // 
            // txtTekrarBarkod
            // 
            this.txtTekrarBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTekrarBarkod.Location = new System.Drawing.Point(9, 94);
            this.txtTekrarBarkod.Name = "txtTekrarBarkod";
            this.txtTekrarBarkod.Size = new System.Drawing.Size(170, 26);
            this.txtTekrarBarkod.TabIndex = 8;
            this.txtTekrarBarkod.Visible = false;
            // 
            // btnTekrarEtiketBasmakIcinBarkodOkut
            // 
            this.btnTekrarEtiketBasmakIcinBarkodOkut.BackColor = System.Drawing.Color.DarkBlue;
            this.btnTekrarEtiketBasmakIcinBarkodOkut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTekrarEtiketBasmakIcinBarkodOkut.ForeColor = System.Drawing.Color.White;
            this.btnTekrarEtiketBasmakIcinBarkodOkut.Location = new System.Drawing.Point(3, 3);
            this.btnTekrarEtiketBasmakIcinBarkodOkut.Name = "btnTekrarEtiketBasmakIcinBarkodOkut";
            this.btnTekrarEtiketBasmakIcinBarkodOkut.Size = new System.Drawing.Size(293, 51);
            this.btnTekrarEtiketBasmakIcinBarkodOkut.TabIndex = 7;
            this.btnTekrarEtiketBasmakIcinBarkodOkut.Text = "Barkod ile Etiket Bas";
            this.btnTekrarEtiketBasmakIcinBarkodOkut.UseVisualStyleBackColor = false;
            this.btnTekrarEtiketBasmakIcinBarkodOkut.Click += new System.EventHandler(this.btnTekrarEtiketBasmakIcinBarkodOkut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Location = new System.Drawing.Point(8, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 66);
            this.panel1.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MediumBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(2, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(293, 51);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Üretim Emirlerini Oku";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.boxLeftPart);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.boxEtiketler);
            this.splitContainer1.Panel2.Controls.Add(this.boxMiktar);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1008, 729);
            this.splitContainer1.SplitterDistance = 682;
            this.splitContainer1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer2Tick);
            // 
            // frmUretim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUretim";
            this.Text = "Mamul Tartı  ve Etiketleme Ekranı ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUretim_FormClosing);
            this.Load += new System.EventHandler(this.frmUretim_Load);
            this.pnlMamuller.ResumeLayout(false);
            this.boxLeftPart.ResumeLayout(false);
            this.boxMiktar.ResumeLayout(false);
            this.pnlMiktar.ResumeLayout(false);
            this.pnlMiktar.PerformLayout();
            this.boxEtiketler.ResumeLayout(false);
            this.pnlEtiketler.ResumeLayout(false);
            this.pnlKoliIslem.ResumeLayout(false);
            this.pnlKoliIslem.PerformLayout();
            this.pnlTekrarEtiketBas.ResumeLayout(false);
            this.pnlTekrarEtiketBas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlMamuller;
        private System.Windows.Forms.GroupBox boxLeftPart;
        private System.Windows.Forms.GroupBox boxMiktar;
        private System.Windows.Forms.FlowLayoutPanel pnlMiktar;
        private System.Windows.Forms.GroupBox boxEtiketler;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel pnlEtiketler;
        private FastReport.Report report1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.RichTextBox rtbOkunan;
        private System.Windows.Forms.RichTextBox rtbLOG;
        private System.Windows.Forms.Button btnKoliBaslat;
        private System.Windows.Forms.Button btn_Koli_Iptal;
        private System.Windows.Forms.Panel pnlKoliIslem;
        private System.Windows.Forms.Label lblKoliToplami;
        private System.Windows.Forms.Label lblKoliStokAdi;
        private System.Windows.Forms.Button btnKoliEtiketiBas;
        private System.Windows.Forms.FlowLayoutPanel pnlSubeler;
        private System.Windows.Forms.Panel pnlTekrarEtiketBas;
        private System.Windows.Forms.Button btnTekrarEtiketYazdir;
        private System.Windows.Forms.Label lblBakodOkutunuz;
        private System.Windows.Forms.TextBox txtTekrarBarkod;
        private System.Windows.Forms.Button btnTekrarEtiketBasmakIcinBarkodOkut;
        private System.Windows.Forms.FlowLayoutPanel pnlMamulGruplari;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
    }
}