namespace yilanOyunu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtOyuncu = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnYardım = new System.Windows.Forms.Button();
            this.btnSkorlariGorntule = new System.Windows.Forms.Button();
            this.rdKolay = new System.Windows.Forms.RadioButton();
            this.rdZor = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPuan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblZaman = new System.Windows.Forms.Label();
            this.lblSalise = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblOzet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(690, 350);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtOyuncu
            // 
            this.txtOyuncu.Location = new System.Drawing.Point(250, 419);
            this.txtOyuncu.Name = "txtOyuncu";
            this.txtOyuncu.Size = new System.Drawing.Size(100, 20);
            this.txtOyuncu.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(358, 417);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYardım
            // 
            this.btnYardım.Location = new System.Drawing.Point(-3, 415);
            this.btnYardım.Name = "btnYardım";
            this.btnYardım.Size = new System.Drawing.Size(75, 32);
            this.btnYardım.TabIndex = 3;
            this.btnYardım.Text = "YARDIM";
            this.btnYardım.UseVisualStyleBackColor = true;
            this.btnYardım.Click += new System.EventHandler(this.btnYardım_Click);
            // 
            // btnSkorlariGorntule
            // 
            this.btnSkorlariGorntule.Location = new System.Drawing.Point(639, 409);
            this.btnSkorlariGorntule.Name = "btnSkorlariGorntule";
            this.btnSkorlariGorntule.Size = new System.Drawing.Size(75, 38);
            this.btnSkorlariGorntule.TabIndex = 4;
            this.btnSkorlariGorntule.Text = "Skorları Görüntüle";
            this.btnSkorlariGorntule.UseVisualStyleBackColor = true;
            this.btnSkorlariGorntule.Click += new System.EventHandler(this.btnSkorlariGorntule_Click);
            // 
            // rdKolay
            // 
            this.rdKolay.AutoSize = true;
            this.rdKolay.Location = new System.Drawing.Point(250, 393);
            this.rdKolay.Name = "rdKolay";
            this.rdKolay.Size = new System.Drawing.Size(86, 17);
            this.rdKolay.TabIndex = 5;
            this.rdKolay.TabStop = true;
            this.rdKolay.Text = "Kolay Seviye";
            this.rdKolay.UseVisualStyleBackColor = true;
            this.rdKolay.CheckedChanged += new System.EventHandler(this.rdKolay_CheckedChanged);
            // 
            // rdZor
            // 
            this.rdZor.AutoSize = true;
            this.rdZor.Location = new System.Drawing.Point(357, 393);
            this.rdZor.Name = "rdZor";
            this.rdZor.Size = new System.Drawing.Size(76, 17);
            this.rdZor.TabIndex = 6;
            this.rdZor.TabStop = true;
            this.rdZor.Text = "Zor Seviye";
            this.rdZor.UseVisualStyleBackColor = true;
            this.rdZor.CheckedChanged += new System.EventHandler(this.rdZor_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puanınız : ";
            // 
            // lblPuan
            // 
            this.lblPuan.AutoSize = true;
            this.lblPuan.Location = new System.Drawing.Point(71, 15);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(13, 13);
            this.lblPuan.TabIndex = 8;
            this.lblPuan.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gecen Sure :";
            // 
            // lblZaman
            // 
            this.lblZaman.AutoSize = true;
            this.lblZaman.Location = new System.Drawing.Point(636, 15);
            this.lblZaman.Name = "lblZaman";
            this.lblZaman.Size = new System.Drawing.Size(34, 13);
            this.lblZaman.TabIndex = 10;
            this.lblZaman.Text = "00:00";
            // 
            // lblSalise
            // 
            this.lblSalise.AutoSize = true;
            this.lblSalise.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSalise.Location = new System.Drawing.Point(669, 16);
            this.lblSalise.Name = "lblSalise";
            this.lblSalise.Size = new System.Drawing.Size(15, 12);
            this.lblSalise.TabIndex = 11;
            this.lblSalise.Text = "00";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblOzet
            // 
            this.lblOzet.AutoSize = true;
            this.lblOzet.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOzet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOzet.Location = new System.Drawing.Point(135, 117);
            this.lblOzet.Name = "lblOzet";
            this.lblOzet.Size = new System.Drawing.Size(88, 24);
            this.lblOzet.TabIndex = 12;
            this.lblOzet.Text = "Özet bilgi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Viner Hand ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Yılan Oyununa Hoşgeldiniz";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(712, 446);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOzet);
            this.Controls.Add(this.lblSalise);
            this.Controls.Add(this.lblZaman);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPuan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdZor);
            this.Controls.Add(this.rdKolay);
            this.Controls.Add(this.btnSkorlariGorntule);
            this.Controls.Add(this.btnYardım);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtOyuncu);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtOyuncu;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnYardım;
        private System.Windows.Forms.Button btnSkorlariGorntule;
        private System.Windows.Forms.RadioButton rdKolay;
        private System.Windows.Forms.RadioButton rdZor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblZaman;
        private System.Windows.Forms.Label lblSalise;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblOzet;
        private System.Windows.Forms.Label label3;
    }
}

