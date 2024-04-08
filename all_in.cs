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
    public partial class all_in : Form
    {
        public string connectionString = connection_string.conn_string.ToString();

        DataTable tablo = new DataTable();
        private void EditUserRefreshDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    string selectQuery = "SELECT * FROM users WITH (NOLOCK)";

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
        DataTable tablo2 = new DataTable();
        private void EditTableRefreshDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    string selectQuery = "select isnull(M.masa_id,0) [Masa Id],isnull(M.masa_no, 0)[Masa No],case when isnull(M.masa_status, 0) = 1 then 'Boş' when isnull(M.masa_status,0)= 0 then 'Dolu' end[Masa Durumu] ,(select U.Name from users as U with(nolock) where U.users_id = isnull(M.masa_users, 0)) [Masa Oluşturan] from Masalar as M with(nolock) order by M.masa_id asc";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Yeni bir DataTable oluştur
                            DataTable newDataTable = new DataTable();

                            // Verileri SqlDataAdapter ile çek ve yeni DataTable'a ekle
                            adapter.Fill(newDataTable);

                            // DataGridView'ın DataSource'unu yeni DataTable ile güncelle
                            dataGridView2.DataSource = newDataTable;

                            // DataTable'ı tablo değişkenine atayarak genel tablo güncellenmiş olur
                            tablo2 = newDataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public all_in()
        {
            InitializeComponent();
        }

        int edit_user_sellect = -1;
        int edit_table_sellect = -1;
        string edit_user_user_info_query = "";     

        private void edit_user_load()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    edit_user_user_info_query = "SELECT  * FROM users AS U WITH (NOLOCK) ";

                    SqlCommand command = new SqlCommand(edit_user_user_info_query, connection);
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

        string edit_table_user_info_query = "";
        private void edit_table_load()
        {
            {

                //users_rec_Id_2
                //MessageBox.Show(UsersRecId);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        //user_info_query = "SELECT  * FROM Masalar AS ms WITH (NOLOCK) ";
                        edit_table_user_info_query = "select isnull(M.masa_id,0) [Masa Id],isnull(M.masa_no, 0)[Masa No],case when isnull(M.masa_status, 0) = 1 then 'Boş' when isnull(M.masa_status,0)= 0 then 'Dolu' end[Masa Durumu] ,(select U.Name from users as U with(nolock) where U.users_id = isnull(M.masa_users, 0)) [Masa Oluşturan] from Masalar as M with(nolock) order by M.masa_id asc";
                        SqlCommand command = new SqlCommand(edit_table_user_info_query, connection);
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
                            dataGridView2.DataSource = tablo;

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
        }
        private void all_in_Load(object sender, EventArgs e)
        {
            edit_user_load();
            edit_table_load();
        }

        private void edit_user_add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // TextBox'ların içeriğini al
                    string name = textBox1.Text;
                    string surname = textBox2.Text;
                    string username = textBox3.Text;
                    string password = textBox4.Text;
                    string kimlik = textBox5.Text;
                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO users (Kimlik, Name, Surname, Username, Password ,users_add_id) VALUES (@kimlik, @name, @surname, @username, @password,\'" + ayar.user_Id.ToString() + "\')";

                    // SqlCommand oluştur
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@kimlik", kimlik);

                        // Komutu çalıştır
                        command.ExecuteNonQuery();
                    }

                    // Veritabanına ekledikten sonra DataGridView'ı güncelle
                    EditUserRefreshDataGridView();

                    // TextBox'ları temizle
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    MessageBox.Show("Kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_user_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit_user_sellect != -1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // TextBox'ların içeriğini al
                        string name = textBox1.Text;
                        string surname = textBox2.Text;
                        string username = textBox3.Text;
                        string password = textBox4.Text;
                        string kimlik = textBox5.Text;
                        string users_id = textBox6.Text;

                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE users SET Name = @name, Surname = @surname, Username = @username, Password = @password , Kimlik = @kimlik WHERE users_id=@users_id";

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@surname", surname);
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@kimlik", kimlik);
                            command.Parameters.AddWithValue("@users_id", users_id);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı güncelle
                        EditUserRefreshDataGridView();

                        MessageBox.Show("Kayıt başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Satın Seçerek Listeleyiniz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_user_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Silme sorgusu
                        string deleteQuery = "DELETE FROM users WHERE users_id = @users_id";

                        // Seçili satırın kimliğini al
                        string users_id = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Parametreyi ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@users_id", users_id);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı günceller
                        EditUserRefreshDataGridView();

                        MessageBox.Show("Kayıt başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Satın Seçerek Listeleyiniz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_user_list_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                edit_user_sellect = dataGridView1.CurrentRow.Index;
            }
            else MessageBox.Show("Kayıt Bulunamadı");

        }

        private void edit_user_clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void edit_table_add_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ayar.user_Id.ToString());
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // TextBox'ların içeriğini al
                    string masa_no = textBox9.Text;
                    string masa_status = textBox8.Text;
                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO Masalar (masa_no, masa_status, masa_users) VALUES (@masa_no, @masa_status, \'" + ayar.user_Id.ToString() + "\')";

                    // SqlCommand oluştur
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                        command.Parameters.AddWithValue("@masa_no", masa_no);
                        command.Parameters.AddWithValue("@masa_status", masa_status);

                        // Komutu çalıştır
                        command.ExecuteNonQuery();
                    }

                    // Veritabanına ekledikten sonra DataGridView'ı güncelle
                    EditTableRefreshDataGridView();

                    // TextBox'ları temizle
                    textBox9.Text = "";

                    MessageBox.Show("Kayıt başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_table_list_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Cells[0].Value != null)
            {
                textBox9.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox8.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox7.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                edit_table_sellect = dataGridView2.CurrentRow.Index;
            }
            else MessageBox.Show("Kayıt Bulunamadı");


        }

        private void edit_table_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit_table_sellect != -1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // TextBox'ların içeriğini al
                        string masa_no = textBox9.Text;
                        string masa_status = textBox8.Text;
                        string masa_id = textBox7.Text;
                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE Masalar SET masa_no = @masa_no, masa_status = @masa_status WHERE masa_id = @masa_id";

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command.Parameters.AddWithValue("@masa_no", masa_no);
                            command.Parameters.AddWithValue("@masa_status", masa_status);
                            command.Parameters.AddWithValue("@masa_id", masa_id);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı güncelle
                        EditTableRefreshDataGridView();

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

        private void edit_table_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow.Cells[0].Value != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Silme sorgusu
                        string deleteQuery = "DELETE FROM Masalar WHERE masa_id = @masa_id";

                        // Seçili satırın kimliğini al
                        string masa_id = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Parametreyi ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@masa_id", masa_id);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı günceller
                        EditTableRefreshDataGridView();

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

        private void edit_table_clear_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox8.Text.ToString()))
            {
                if (textBox8.Text.ToString() == "Boş")
                    textBox8.Text = "1";
                if (textBox8.Text.ToString() == "Dolu")
                    textBox8.Text = "0";
            }
        }
    }
}
