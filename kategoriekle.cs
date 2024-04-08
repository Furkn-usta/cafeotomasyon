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

namespace restaurant_automation
{
    public partial class kategoriekle : Form
    {
        public kategoriekle()
        {
            InitializeComponent();
        }

        DataTable tablo = new DataTable();
        //public string connectionString = "Server=ENKAY;Database=ExtremeDeneme;User Id=sa;Password=3xtreme;";
        public string connectionString = connection_string.conn_string.ToString();

        string user_info_query = "";

        int sellect = -1;

        private void RefreshDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    string selectQuery = "select isnull(C.category_id,0) [Kategori ID], isnull(C.category_name,'') [Kategori Adı] from Category as C with (nolock)";

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

        private void kategoriekle_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    user_info_query = "select isnull(C.category_id,0) [Kategori ID], isnull(C.category_name,'') [Kategori Adı] from Category as C with (nolock)";

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

        private void category_ekle_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ayar.user_Id.ToString());
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // TextBox'ların içeriğini al
                    string category_id = textBox1.Text;
                    string category_name = textBox2.Text;
                    string category_sub_id = textBox3.Text;
                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO Category (category_name, category_sub_id) VALUES (@category_name, @category_sub_id)";

                    // SqlCommand oluştur
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                        command.Parameters.AddWithValue("@category_name", category_name);
                        command.Parameters.AddWithValue("@category_sub_id", category_sub_id);

                        // Komutu çalıştır
                        command.ExecuteNonQuery();
                    }

                    // Veritabanına ekledikten sonra DataGridView'ı güncelle
                    RefreshDataGridView();

                    // TextBox'ları temizle
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void category_guncelleme_Click(object sender, EventArgs e)
        {
            try
            {
                if (sellect != -1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // TextBox'ların içeriğini al
                        string category_id = textBox1.Text;
                        string category_name = textBox2.Text;
                        string category_sub_id = textBox3.Text;
                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE Category SET category_name = @category_name, category_sub_id = @category_sub_id WHERE category_id = @category_id";

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@category_name", category_name);
                            command.Parameters.AddWithValue("@category_sub_id", category_sub_id);

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

        private void category_listele_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                sellect = dataGridView1.CurrentRow.Index;
            }
            else MessageBox.Show("Kayıt Bulunamadı");

        }

        private void category_text_sil_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void category_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Silme sorgusu
                        string deleteQuery = "DELETE FROM Category WHERE category_id = @category_id";

                        // Seçili satırın kimliğini al
                        string category_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Parametreyi ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@category_id", category_id);

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
    }
}
