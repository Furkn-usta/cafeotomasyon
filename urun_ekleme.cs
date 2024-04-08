using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant_automation
{
    public partial class urun_ekleme : Form
    {
        public urun_ekleme()
        {
            InitializeComponent();
            LoadCategories();
        }
        DataTable tablo = new DataTable();
        //public string connectionString = "Server=ENKAY;Database=ExtremeDeneme;User Id=sa;Password=3xtreme;";
        public string connectionString = connection_string.conn_string.ToString();

        string user_info_query = "";
       
        int sellect = -1;
  
        private void LoadCategories()
        {
            string query = "SELECT category_name FROM Category with (nolock)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string categoryName = reader["category_name"].ToString();
                            comboBox1.Items.Add(categoryName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        private void RefreshDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    string selectQuery = "SELECT isnull(id,0) [ID], isnull(pName,0) [Ürün Adı], isnull(price,0) [Fiyat] ,isnull(piece,0) [Adet],(select isnull(category_name,'') from Category C with (nolock) where C.category_id=P.category_id)[Kategori] FROM Products P WITH (NOLOCK)";

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
        }


        private void urun_ekleme_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    user_info_query = "SELECT isnull(id,0) [ID], isnull(pName,0) [Ürün Adı], isnull(price,0) [Fiyat] ,isnull(piece,0) [Adet],(select isnull(category_name,'') from Category C with (nolock) where C.category_id=P.category_id)[Kategori] FROM Products P WITH (NOLOCK)";

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

        private void urun_ekle_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer bir kategori seçili değilse, diğer işlemleri engelle ve metodu sonlandır
            }
            //MessageBox.Show(ayar.user_Id.ToString());
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // TextBox'ların içeriğini al
                    string urun_id = textBox1.Text;
                    string urun_adi = textBox2.Text;
                    string urun_fiyati = textBox3.Text;
                    string urun_adet = textBox4.Text;
                    string category_id = comboBox1.Text;
                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO Products (pName, price,piece,category_id) VALUES (@urun_adi,@urun_fiyati,@urun_adet,(select isnull(C.category_id,0) from Category C where C.category_name='"+ category_id.ToString() + "'))";

                    // SqlCommand oluştur
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağlar
                        command.Parameters.AddWithValue("@urun_adi", urun_adi);
                        command.Parameters.AddWithValue("@urun_fiyati", urun_fiyati);
                        command.Parameters.AddWithValue("@urun_adet", urun_adet);
                        command.Parameters.AddWithValue("@category_id", category_id);

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
                    comboBox1.Text = "";
                    MessageBox.Show("Kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void urun_listele_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

             
                sellect = dataGridView1.CurrentRow.Index;

            }
            else MessageBox.Show("Kayıt Bulunamadı");


        }
       
        private void urun_guncelleme_Click(object sender, EventArgs e)
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
                        string pName = textBox2.Text;
                        string price = textBox3.Text;
                        string piece = textBox4.Text;
                        string category_id = comboBox1.Text;
                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE Products SET category_id=(select isnull(C.category_id,0) from Category C where C.category_name=\'"+ category_id.ToString() + "\'),pName = @pName, price = @price, piece=@piece WHERE id = @id";

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@price", price);
                            command.Parameters.AddWithValue("@pName", pName);
                            command.Parameters.AddWithValue("@piece", piece);

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

        private void urun_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Silme sorgusu
                        string deleteQuery = "DELETE FROM Products where id = @id";

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

        private void urun_text_sil_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";

        }
    }
}
