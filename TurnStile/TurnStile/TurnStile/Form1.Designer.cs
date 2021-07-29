namespace TurnStile
{
    partial class Form1
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
            this.btnGirisAc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPortTmp = new System.IO.Ports.SerialPort(this.components);
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnCikisAc = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerGetDevices = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlTurnstiles = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTurnstileStatus = new System.Windows.Forms.Label();
            this.lblLastError = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGirisAc
            // 
            this.btnGirisAc.Location = new System.Drawing.Point(5, 346);
            this.btnGirisAc.Name = "btnGirisAc";
            this.btnGirisAc.Size = new System.Drawing.Size(75, 23);
            this.btnGirisAc.TabIndex = 0;
            this.btnGirisAc.Text = "Giris Ac";
            this.btnGirisAc.UseVisualStyleBackColor = true;
            this.btnGirisAc.Click += new System.EventHandler(this.btnGirisAc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // serialPortTmp
            // 
            this.serialPortTmp.PortName = "COM7";
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbLog.Location = new System.Drawing.Point(274, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(373, 408);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // btnCikisAc
            // 
            this.btnCikisAc.Location = new System.Drawing.Point(86, 346);
            this.btnCikisAc.Name = "btnCikisAc";
            this.btnCikisAc.Size = new System.Drawing.Size(87, 23);
            this.btnCikisAc.TabIndex = 5;
            this.btnCikisAc.Text = "Çıkış Aç";
            this.btnCikisAc.UseVisualStyleBackColor = true;
            this.btnCikisAc.Click += new System.EventHandler(this.btnCikisAc_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerGetDevices
            // 
            this.timerGetDevices.Enabled = true;
            this.timerGetDevices.Interval = 5000;
            this.timerGetDevices.Tick += new System.EventHandler(this.timerGetDevices_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnlTurnstiles
            // 
            this.pnlTurnstiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTurnstiles.Location = new System.Drawing.Point(0, 0);
            this.pnlTurnstiles.Name = "pnlTurnstiles";
            this.pnlTurnstiles.Size = new System.Drawing.Size(274, 100);
            this.pnlTurnstiles.TabIndex = 9;
            // 
            // lblTurnstileStatus
            // 
            this.lblTurnstileStatus.AutoSize = true;
            this.lblTurnstileStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTurnstileStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTurnstileStatus.Location = new System.Drawing.Point(0, 100);
            this.lblTurnstileStatus.Name = "lblTurnstileStatus";
            this.lblTurnstileStatus.Size = new System.Drawing.Size(162, 25);
            this.lblTurnstileStatus.TabIndex = 10;
            this.lblTurnstileStatus.Text = "Turnstile Status";
            // 
            // lblLastError
            // 
            this.lblLastError.AutoSize = true;
            this.lblLastError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLastError.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLastError.ForeColor = System.Drawing.Color.Red;
            this.lblLastError.Location = new System.Drawing.Point(0, 375);
            this.lblLastError.Name = "lblLastError";
            this.lblLastError.Size = new System.Drawing.Size(206, 33);
            this.lblLastError.TabIndex = 11;
            this.lblLastError.Text = "Error Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblLastError);
            this.Controls.Add(this.lblTurnstileStatus);
            this.Controls.Add(this.pnlTurnstiles);
            this.Controls.Add(this.btnCikisAc);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGirisAc);
            this.Name = "Form1";
            this.Text = "ElektraWeb Turnstile Control Software";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGirisAc;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPortTmp;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnCikisAc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerGetDevices;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.FlowLayoutPanel pnlTurnstiles;
        private System.Windows.Forms.Label lblTurnstileStatus;
        private System.Windows.Forms.Label lblLastError;
        private System.Windows.Forms.Button button1;
    }
}

