using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace restaurant_automation
{
    public partial class malzeme_ekle : Form
    {
        public malzeme_ekle()
        {
            InitializeComponent();
            LoadUnitSize();
        }
        DataTable tablo = new DataTable();
        //public string connectionString = "Server=ENKAY;Database=ExtremeDeneme;User Id=sa;Password=3xtreme;";
        public string connectionString = connection_string.conn_string.ToString();

        string user_info_query = "";

        int sellect = -1;

        private void LoadUnitSize()
        {
            birim_combo.Items.Clear();
            birim_combo.Items.Add("Kg");
            birim_combo.Items.Add("Lt");
            birim_combo.Items.Add("Adet");
        }
        private void RefreshDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    string selectQuery = "select ISNULL(M.id,0) [ID] ,ISNULL(M.malzeme_adi,'') [Malzeme Adı] , isnull(M.birim_fiyat,0) [Birim Fiyat], ISNULL(M.birim,'') [Birim], isnull(M.adet_gramaj,0) [Adet Gramaj] from Malzemeler M with (nolock) ";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Yeni bir DataTable oluştur
                            DataTable newDataTable = new DataTable();

                            // Verileri SqlDataAdapter ile çek ve yeni DataTable'a ekle
                            adapter.Fill(newDataTable);

                            // DataGridView'ın DataSource'unu yeni DataTable ile güncelle
                            dataGridView1.DataSource = newDataTable;

                            // DataTable'ı tablo değişkenine atayarak genel tablo güncellenmiş olur
                            tablo = newDataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadUnitSize();
}

        private void malzeme_ekle_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    user_info_query = "select ISNULL(M.id,0) [ID] ,ISNULL(M.malzeme_adi,'') [Malzeme Adı] , isnull(M.birim_fiyat,0) [Birim Fiyat], ISNULL(M.birim,'') [Birim], isnull(M.adet_gramaj,0) [Adet Gramaj] from Malzemeler M with (nolock) ";

                    SqlCommand command = new SqlCommand(user_info_query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable tablo = new DataTable();

                    // SqlDataReader'dan gelen sütun isimlerini al
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);

                        // Eğer DataTable'da bu isimde bir sütun yoksa ekle
                        if (!tablo.Columns.Contains(columnName))
                        {
                            tablo.Columns.Add(columnName, typeof(string));
                        }
                    }

                    while (reader.Read())
                    {
                        // Her bir satırdaki verileri DataTable'a ekleyebilirsiniz
                        object[] values = new object[reader.FieldCount];
                        reader.GetValues(values);
                        tablo.Rows.Add(values);
                        dataGridView1.DataSource = tablo;

                    }

                    int rowCount = tablo.Rows.Count;
                    // MessageBox.Show($"Toplam {rowCount} kayıt döndü.");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


        }
        private void malz_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // TextBox'ların içeriğini al
                    string malzeme_id = textBox1.Text;
                    string malzeme_adi = textBox2.Text;
                    string birim_fiyat = textBox3.Text;
                    string birim = birim_combo.Text;
                    string adet_gramaj = textBox4.Text;
                    adet_gramaj = adet_gramaj.ToString().Replace(",", ".");
                    birim_fiyat = birim_fiyat.ToString().Replace(",", ".");
                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO Malzemeler (malzeme_adi, birim_fiyat,birim,adet_gramaj) VALUES (@malzeme_adi,@birim_fiyat,@birim,@adet_gramaj)";

                    // SqlCommand oluştur
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağlar
                        command.Parameters.AddWithValue("@malzeme_adi", malzeme_adi);
                        command.Parameters.AddWithValue("@birim_fiyat", birim_fiyat);
                        command.Parameters.AddWithValue("@birim", birim);
                        command.Parameters.AddWithValue("@adet_gramaj", adet_gramaj);

                        // Komutu çalıştır
                        command.ExecuteNonQuery();
                    }

                    // Veritabanına ekledikten sonra DataGridView'ı güncelle
                    RefreshDataGridView();
                    // TextBox'ları temizle
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    birim_combo.Text = "";
                    MessageBox.Show("Kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void malz_guncelleme_Click(object sender, EventArgs e)
        {

            try
            {
                if (sellect != -1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // TextBox'ların içeriğini al
                        string id = textBox1.Text;
                        string malzeme_adi = textBox2.Text;
                        string birim_fiyat = textBox3.Text;
                        string birim = birim_combo.Text;
                        string adet_gramaj = textBox4.Text;
                        adet_gramaj = adet_gramaj.ToString().Replace(",", ".");
                        birim_fiyat = birim_fiyat.ToString().Replace(",", ".");
                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE Malzemeler SET malzeme_adi=@malzeme_adi,birim_fiyat = @birim_fiyat, birim = @birim, adet_gramaj=@adet_gramaj WHERE id = @id";
                        //MessageBox.Show(updateQuery);
                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@malzeme_adi", malzeme_adi);
                            command.Parameters.AddWithValue("@birim_fiyat", birim_fiyat);
                            command.Parameters.AddWithValue("@birim", birim);
                            command.Parameters.AddWithValue("@adet_gramaj", adet_gramaj);
                            command.Parameters.AddWithValue("@id", id);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı güncelle
                        RefreshDataGridView();

                        MessageBox.Show("Kayıt başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Satır Seçerek Listeleyiniz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void malz_listele_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                birim_combo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                sellect = dataGridView1.CurrentRow.Index;
            }
            else MessageBox.Show("Kayıt Bulunamadı");
        }

        private void malz_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Silme sorgusu
                        string deleteQuery = "DELETE FROM Malzemeler WHERE id = @id";

                        // Seçili satırın kimliğini al
                        string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Parametreyi ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@id", id);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı günceller
                        RefreshDataGridView();

                        MessageBox.Show("Kayıt başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Satır Seçerek Listeleyiniz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void malz_text_sil_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            birim_combo.Text = "";
        }
    }
}
