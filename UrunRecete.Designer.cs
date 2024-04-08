namespace restaurant_automation
{
    partial class UrunRecete
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.urun_adi = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.urunleri_getir = new System.Windows.Forms.Button();
            this.kul_miktar = new System.Windows.Forms.Label();
            this.brm_fiyat = new System.Windows.Forms.Label();
            this.temizle = new System.Windows.Forms.Button();
            this.hesapla = new System.Windows.Forms.Button();
            this.fire1 = new System.Windows.Forms.Label();
            this.fire2 = new System.Windows.Forms.Label();
            this.hes_Fiy1 = new System.Windows.Forms.Label();
            this.kar1 = new System.Windows.Forms.Label();
            this.topfiyat_ = new System.Windows.Forms.TextBox();
            this.top_fiy = new System.Windows.Forms.Label();
            this.karoran = new System.Windows.Forms.TextBox();
            this.kar_oran = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Maroon;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(811, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(313, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // urun_adi
            // 
            this.urun_adi.AutoSize = true;
            this.urun_adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urun_adi.ForeColor = System.Drawing.Color.Maroon;
            this.urun_adi.Location = new System.Drawing.Point(9, 12);
            this.urun_adi.Name = "urun_adi";
            this.urun_adi.Size = new System.Drawing.Size(66, 16);
            this.urun_adi.TabIndex = 3;
            this.urun_adi.Text = "Ürün Adı";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 69);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(121, 319);
            this.checkedListBox1.TabIndex = 4;
            // 
            // urunleri_getir
            // 
            this.urunleri_getir.Location = new System.Drawing.Point(12, 400);
            this.urunleri_getir.Name = "urunleri_getir";
            this.urunleri_getir.Size = new System.Drawing.Size(121, 21);
            this.urunleri_getir.TabIndex = 5;
            this.urunleri_getir.Text = "Ürünleri Getir";
            this.urunleri_getir.UseVisualStyleBackColor = true;
            this.urunleri_getir.Click += new System.EventHandler(this.urunleri_getir_Click);
            // 
            // kul_miktar
            // 
            this.kul_miktar.AutoSize = true;
            this.kul_miktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kul_miktar.ForeColor = System.Drawing.Color.Maroon;
            this.kul_miktar.Location = new System.Drawing.Point(169, 33);
            this.kul_miktar.Name = "kul_miktar";
            this.kul_miktar.Size = new System.Drawing.Size(120, 16);
            this.kul_miktar.TabIndex = 6;
            this.kul_miktar.Text = "Kullanılan Miktar";
            // 
            // brm_fiyat
            // 
            this.brm_fiyat.AutoSize = true;
            this.brm_fiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.brm_fiyat.ForeColor = System.Drawing.Color.Maroon;
            this.brm_fiyat.Location = new System.Drawing.Point(315, 33);
            this.brm_fiyat.Name = "brm_fiyat";
            this.brm_fiyat.Size = new System.Drawing.Size(80, 16);
            this.brm_fiyat.TabIndex = 7;
            this.brm_fiyat.Text = "Birim Fiyat";
            // 
            // temizle
            // 
            this.temizle.Location = new System.Drawing.Point(12, 427);
            this.temizle.Name = "temizle";
            this.temizle.Size = new System.Drawing.Size(121, 21);
            this.temizle.TabIndex = 8;
            this.temizle.Text = "Temizle";
            this.temizle.UseVisualStyleBackColor = true;
            this.temizle.Click += new System.EventHandler(this.temizle_Click);
            // 
            // hesapla
            // 
            this.hesapla.Location = new System.Drawing.Point(12, 454);
            this.hesapla.Name = "hesapla";
            this.hesapla.Size = new System.Drawing.Size(121, 21);
            this.hesapla.TabIndex = 9;
            this.hesapla.Text = "Hesapla";
            this.hesapla.UseVisualStyleBackColor = true;
            this.hesapla.Click += new System.EventHandler(this.hesapla_Click);
            // 
            // fire1
            // 
            this.fire1.AutoSize = true;
            this.fire1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fire1.ForeColor = System.Drawing.Color.Maroon;
            this.fire1.Location = new System.Drawing.Point(416, 33);
            this.fire1.Name = "fire1";
            this.fire1.Size = new System.Drawing.Size(46, 16);
            this.fire1.TabIndex = 10;
            this.fire1.Text = "Fire 1";
            // 
            // fire2
            // 
            this.fire2.AutoSize = true;
            this.fire2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fire2.ForeColor = System.Drawing.Color.Maroon;
            this.fire2.Location = new System.Drawing.Point(474, 33);
            this.fire2.Name = "fire2";
            this.fire2.Size = new System.Drawing.Size(46, 16);
            this.fire2.TabIndex = 11;
            this.fire2.Text = "Fire 2";
            // 
            // hes_Fiy1
            // 
            this.hes_Fiy1.AutoSize = true;
            this.hes_Fiy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hes_Fiy1.ForeColor = System.Drawing.Color.Maroon;
            this.hes_Fiy1.Location = new System.Drawing.Point(549, 33);
            this.hes_Fiy1.Name = "hes_Fiy1";
            this.hes_Fiy1.Size = new System.Drawing.Size(129, 16);
            this.hes_Fiy1.TabIndex = 12;
            this.hes_Fiy1.Text = "Hesaplanan Fiyat";
            // 
            // kar1
            // 
            this.kar1.AutoSize = true;
            this.kar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kar1.ForeColor = System.Drawing.Color.Maroon;
            this.kar1.Location = new System.Drawing.Point(715, 33);
            this.kar1.Name = "kar1";
            this.kar1.Size = new System.Drawing.Size(30, 16);
            this.kar1.TabIndex = 13;
            this.kar1.Text = "Kâr";
            // 
            // topfiyat_
            // 
            this.topfiyat_.Location = new System.Drawing.Point(705, 428);
            this.topfiyat_.Name = "topfiyat_";
            this.topfiyat_.Size = new System.Drawing.Size(100, 20);
            this.topfiyat_.TabIndex = 14;
            // 
            // top_fiy
            // 
            this.top_fiy.AutoSize = true;
            this.top_fiy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.top_fiy.ForeColor = System.Drawing.Color.Maroon;
            this.top_fiy.Location = new System.Drawing.Point(707, 405);
            this.top_fiy.Name = "top_fiy";
            this.top_fiy.Size = new System.Drawing.Size(98, 16);
            this.top_fiy.TabIndex = 15;
            this.top_fiy.Text = "Toplam Fiyat";
            // 
            // karoran
            // 
            this.karoran.Location = new System.Drawing.Point(599, 427);
            this.karoran.Name = "karoran";
            this.karoran.Size = new System.Drawing.Size(100, 20);
            this.karoran.TabIndex = 16;
            // 
            // kar_oran
            // 
            this.kar_oran.AutoSize = true;
            this.kar_oran.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kar_oran.ForeColor = System.Drawing.Color.Maroon;
            this.kar_oran.Location = new System.Drawing.Point(618, 405);
            this.kar_oran.Name = "kar_oran";
            this.kar_oran.Size = new System.Drawing.Size(71, 16);
            this.kar_oran.TabIndex = 17;
            this.kar_oran.Text = "Kar Oranı";
            // 
            // UrunRecete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1167, 476);
            this.Controls.Add(this.kar_oran);
            this.Controls.Add(this.karoran);
            this.Controls.Add(this.top_fiy);
            this.Controls.Add(this.topfiyat_);
            this.Controls.Add(this.kar1);
            this.Controls.Add(this.hes_Fiy1);
            this.Controls.Add(this.fire2);
            this.Controls.Add(this.fire1);
            this.Controls.Add(this.hesapla);
            this.Controls.Add(this.temizle);
            this.Controls.Add(this.brm_fiyat);
            this.Controls.Add(this.kul_miktar);
            this.Controls.Add(this.urunleri_getir);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.urun_adi);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "UrunRecete";
            this.Text = "UrunRecete";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label urun_adi;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button urunleri_getir;
        private System.Windows.Forms.Label kul_miktar;
        private System.Windows.Forms.Label brm_fiyat;
        private System.Windows.Forms.Button temizle;
        private System.Windows.Forms.Button hesapla;
        private System.Windows.Forms.Label fire1;
        private System.Windows.Forms.Label fire2;
        private System.Windows.Forms.Label hes_Fiy1;
        private System.Windows.Forms.Label kar1;
        private System.Windows.Forms.TextBox topfiyat_;
        private System.Windows.Forms.Label top_fiy;
        private System.Windows.Forms.TextBox karoran;
        private System.Windows.Forms.Label kar_oran;
    }
}