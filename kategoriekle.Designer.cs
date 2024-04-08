namespace restaurant_automation
{
    partial class kategoriekle
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.category_text_sil = new System.Windows.Forms.Button();
            this.category_listele = new System.Windows.Forms.Button();
            this.category_guncelleme = new System.Windows.Forms.Button();
            this.category_sil = new System.Windows.Forms.Button();
            this.category_ekle = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 225);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 48;
            this.textBox3.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(13, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Alt Kategori:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(13, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Kategori Adı:";
            // 
            // category_text_sil
            // 
            this.category_text_sil.BackColor = System.Drawing.Color.Maroon;
            this.category_text_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category_text_sil.ForeColor = System.Drawing.Color.White;
            this.category_text_sil.Location = new System.Drawing.Point(285, 406);
            this.category_text_sil.Name = "category_text_sil";
            this.category_text_sil.Size = new System.Drawing.Size(120, 30);
            this.category_text_sil.TabIndex = 44;
            this.category_text_sil.Text = "Temizle";
            this.category_text_sil.UseVisualStyleBackColor = false;
            this.category_text_sil.Click += new System.EventHandler(this.category_text_sil_Click);
            // 
            // category_listele
            // 
            this.category_listele.BackColor = System.Drawing.Color.Maroon;
            this.category_listele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category_listele.ForeColor = System.Drawing.Color.White;
            this.category_listele.Location = new System.Drawing.Point(285, 345);
            this.category_listele.Name = "category_listele";
            this.category_listele.Size = new System.Drawing.Size(120, 30);
            this.category_listele.TabIndex = 43;
            this.category_listele.Text = "Listele";
            this.category_listele.UseVisualStyleBackColor = false;
            this.category_listele.Click += new System.EventHandler(this.category_listele_Click);
            // 
            // category_guncelleme
            // 
            this.category_guncelleme.BackColor = System.Drawing.Color.Maroon;
            this.category_guncelleme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category_guncelleme.ForeColor = System.Drawing.Color.White;
            this.category_guncelleme.Location = new System.Drawing.Point(285, 201);
            this.category_guncelleme.Name = "category_guncelleme";
            this.category_guncelleme.Size = new System.Drawing.Size(120, 30);
            this.category_guncelleme.TabIndex = 42;
            this.category_guncelleme.Text = "Güncelleme";
            this.category_guncelleme.UseVisualStyleBackColor = false;
            this.category_guncelleme.Click += new System.EventHandler(this.category_guncelleme_Click);
            // 
            // category_sil
            // 
            this.category_sil.BackColor = System.Drawing.Color.Maroon;
            this.category_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category_sil.ForeColor = System.Drawing.Color.White;
            this.category_sil.Location = new System.Drawing.Point(285, 275);
            this.category_sil.Name = "category_sil";
            this.category_sil.Size = new System.Drawing.Size(120, 30);
            this.category_sil.TabIndex = 41;
            this.category_sil.Text = "Silme";
            this.category_sil.UseVisualStyleBackColor = false;
            this.category_sil.Click += new System.EventHandler(this.category_sil_Click);
            // 
            // category_ekle
            // 
            this.category_ekle.BackColor = System.Drawing.Color.Maroon;
            this.category_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category_ekle.ForeColor = System.Drawing.Color.White;
            this.category_ekle.Location = new System.Drawing.Point(285, 125);
            this.category_ekle.Name = "category_ekle";
            this.category_ekle.Size = new System.Drawing.Size(120, 30);
            this.category_ekle.TabIndex = 40;
            this.category_ekle.Text = "Kategori Ekle";
            this.category_ekle.UseVisualStyleBackColor = false;
            this.category_ekle.Click += new System.EventHandler(this.category_ekle_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(13, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Kategori No:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Maroon;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Maroon;
            this.dataGridView1.Location = new System.Drawing.Point(485, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(461, 465);
            this.dataGridView1.TabIndex = 37;
            // 
            // kategoriekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1007, 557);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.category_text_sil);
            this.Controls.Add(this.category_listele);
            this.Controls.Add(this.category_guncelleme);
            this.Controls.Add(this.category_sil);
            this.Controls.Add(this.category_ekle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "kategoriekle";
            this.Text = "kategoriekle";
            this.Load += new System.EventHandler(this.kategoriekle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button category_text_sil;
        private System.Windows.Forms.Button category_listele;
        private System.Windows.Forms.Button category_guncelleme;
        private System.Windows.Forms.Button category_sil;
        private System.Windows.Forms.Button category_ekle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}