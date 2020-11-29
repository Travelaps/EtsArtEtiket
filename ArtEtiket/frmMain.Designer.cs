namespace ArtEtiket
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MenuBar = new System.Windows.Forms.ToolStrip();
            this.btnStok = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnParcalama = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUretim = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuServerBaglantisi = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MenuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStok,
            this.toolStripSeparator1,
            this.btnParcalama,
            this.toolStripSeparator2,
            this.btnUretim,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuBar.Size = new System.Drawing.Size(784, 38);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "toolStrip1";
            // 
            // btnStok
            // 
            this.btnStok.AutoSize = false;
            this.btnStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(70, 35);
            this.btnStok.Text = "Stok";
            this.btnStok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnParcalama
            // 
            this.btnParcalama.AutoSize = false;
            this.btnParcalama.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnParcalama.Image = ((System.Drawing.Image)(resources.GetObject("btnParcalama.Image")));
            this.btnParcalama.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParcalama.Name = "btnParcalama";
            this.btnParcalama.Size = new System.Drawing.Size(70, 35);
            this.btnParcalama.Text = "Parçalama";
            this.btnParcalama.Click += new System.EventHandler(this.btnParcalama_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnUretim
            // 
            this.btnUretim.AutoSize = false;
            this.btnUretim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUretim.Image = ((System.Drawing.Image)(resources.GetObject("btnUretim.Image")));
            this.btnUretim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUretim.Name = "btnUretim";
            this.btnUretim.Size = new System.Drawing.Size(70, 35);
            this.btnUretim.Text = "Üretim";
            this.btnUretim.Click += new System.EventHandler(this.btnUretim_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerBaglantisi});
            this.toolStripDropDownButton1.Image = global::ArtEtiket.Properties.Resources.dbOnline;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 35);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // mnuServerBaglantisi
            // 
            this.mnuServerBaglantisi.Name = "mnuServerBaglantisi";
            this.mnuServerBaglantisi.Size = new System.Drawing.Size(176, 22);
            this.mnuServerBaglantisi.Text = "Server Bağlantısı";
            this.mnuServerBaglantisi.Click += new System.EventHandler(this.mnuServerBaglantisi_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "Arteus Etiket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MenuBar;
        private System.Windows.Forms.ToolStripButton btnStok;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton btnParcalama;
        private System.Windows.Forms.ToolStripButton btnUretim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuServerBaglantisi;
    }
}

