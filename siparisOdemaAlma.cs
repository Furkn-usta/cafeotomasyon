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
    public partial class siparisOdemaAlma : Form
    {
        public siparisOdemaAlma()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
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
                    string selectQuery = "SELECT  isnull(masa_no,'') [Masa Adı], isnull(masa_id,0) [Masa Numarası] FROM Masalar AS ms WITH (NOLOCK) where ms.masa_status=0 order by ms.masa_id asc";

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
        private void RefreshDataGridView3()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string masa_adi_ = textBox1.Text;
                    string masa_id_ = textBox2.Text;
                    connection.Open();
                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    //string selectQuery = "SELECT * FROM SiparisUrun WITH (NOLOCK) ";




                    string  selectQuery = " select isnull(su.SiparisUrunNo,0) [Siparis ID] ,isnull(p.pName,'') [Ürün Adı],isnull(m.masa_no,'') [Masa Adı], case when isnull(to_offer,0)=0 then isnull(p.price,0)  when isnull(to_offer,0)=1 then 0 end [Ürün Fiyatı]  ";
                    selectQuery += " from dbo.SiparisUrun su with (nolock) ";
                    selectQuery += " left join Masalar m with (nolock) on m.masa_id=su.masa_id ";
                    selectQuery += " left join Products p with (nolock) on p.id=su.UrunNo";
                    selectQuery += " where su.masa_id=\'" + masa_id_.ToString() + "\' and isnull(su.is_products_canceled,0)=0 and m.masa_no=\'" + masa_adi_.ToString() + "\' and isnull(su.SiparisNo,0)=0";



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
        private void siparisOdemaAlma_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    user_info_query = "SELECT  isnull(masa_no,\'\') [Masa Adı], isnull(masa_id,0) [Masa Numarası] FROM Masalar AS ms WITH (NOLOCK) where ms.masa_status=0";

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            // Eğer bir satır tıklandıysa
            if (selectedRowIndex >= 0)
            {
                // Seçili satırdaki verileri alalım
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                string cellValue1 = selectedRow.Cells["Masa Adı"].Value.ToString(); // Sütun adını projenize uygun değiştirin
                string cellValue2 = selectedRow.Cells["Masa Numarası"].Value.ToString(); // Sütun adını projenize uygun değiştirin


                // TextBox'a verileri aktaralım
                textBox1.Text = cellValue1; // TextBox'a uygun bir şekilde aktarabilirsiniz
                textBox2.Text = cellValue2; // TextBox'a uygun bir şekilde aktarabilirsiniz
            }
        }

        private void masa_sec_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string masa_adi_ = textBox1.Text;
                    string masa_id_ = textBox2.Text;
                    connection.Open();
               
                    user_info_query = " select isnull(su.SiparisUrunNo,0) [Siparis ID] ,isnull(p.pName,'') [Ürün Adı],isnull(m.masa_no,'') [Masa Adı], isnull(p.price,0) [Ürün Fiyatı]  ";
                    user_info_query += " from dbo.SiparisUrun su with (nolock) ";
                    user_info_query += " left join Masalar m with (nolock) on m.masa_id=su.masa_id ";
                    user_info_query += " left join Products p with (nolock) on p.id=su.UrunNo";
                    user_info_query += " where su.masa_id=\'" + masa_id_.ToString() + "\' and isnull(su.is_products_canceled,0)=0 and  isnull(SiparisNo,0)=0 and m.masa_no=\'" + masa_adi_.ToString()+"\'";

                    SqlCommand command = new SqlCommand(user_info_query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable tablo2 = new DataTable();

                    // SqlDataReader'dan gelen sütun isimlerini al
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);

                        // Eğer DataTable'da bu isimde bir sütun yoksa ekle
                        if (!tablo2.Columns.Contains(columnName))
                        {
                            tablo2.Columns.Add(columnName, typeof(string));
                        }
                    }

                    while (reader.Read())
                    {
                        // Her bir satırdaki verileri DataTable'a ekleyebilirsiniz
                        object[] values = new object[reader.FieldCount];
                        reader.GetValues(values);
                        tablo2.Rows.Add(values);
                        dataGridView2.DataSource = tablo2;

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
       
        private void hesapla_Click(object sender, EventArgs e)
        {
            // Her butona tıklandığında toplam değişkenini sıfırla
            decimal toplamFiyat = 0;

            // DataGridView2 üzerinde seçili satırları kontrol et
            foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
            {
                // Her seçili satırdaki "Ürün Fiyatı" kolonunun değerini alın
                object cellValue = selectedRow.Cells["Ürün Fiyatı"].Value;

                // Eğer hücre değeri sayısal bir değerse toplama ekleyin
                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal fiyat))
                {
                    toplamFiyat += fiyat;
                }
            }

            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                textBox3.Text = Convert.ToString(Convert.ToDecimal(toplamFiyat) - (Convert.ToDecimal(toplamFiyat) * Convert.ToDecimal(textBox5.Text) / 100));
                //MessageBox.Show("test");
            }
            else
            {
                // TextBox3'e toplam fiyatı yazdırın
                textBox3.Text = toplamFiyat.ToString("N2");
            }
        }

        private void odeme_al_Click(object sender, EventArgs e)
        {
            string sip_no_id = "0";

            // DataGridView2 üzerinde seçili satırları kontrol et
            foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
            {
                // Her seçili satırdaki "Ürün Fiyatı" kolonunun değerini alın
                object cellValue = selectedRow.Cells["Siparis ID"].Value;

                // Eğer hücre değeri sayısal bir değerse toplama ekleyin
                if (cellValue != null && cellValue.ToString()!="")
                {
                    sip_no_id += ","+cellValue.ToString();
                }
            }
            textBox4.Text = sip_no_id.ToString();
            /**/
            if (dataGridView2.CurrentRow.Cells[0].Value != null)
            {
               
                sellect = dataGridView2.CurrentRow.Index;
            }
            
            else MessageBox.Show("Kayıt Bulunamadı");
            
            try
            {
                if (sellect != -1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // TextBox'ların içeriğini al
                       // string masa_adi_ = textBox1.Text;
                        string masa_id_ = textBox2.Text;
                        string discount = textBox5.Text;

                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE SiparisUrun SET SiparisNo = 1 , to_offer = 0 , discount = @discount  WHERE masa_id = @masa_id_ and SiparisUrunNo in (" + sip_no_id.ToString()+ ")";
                        string updateQuery2 = "UPDATE Masalar SET masa_status = 1 WHERE masa_id = @masa_id_ ";
                       // string updateQuery3 = "UPDATE SiparisUrun SET discount = @discount WHERE  SiparisUrunNo in (" + sip_no_id.ToString() + ")";

                        // MessageBox.Show(updateQuery);
                        // MessageBox.Show(updateQuery2);
                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command.Parameters.AddWithValue("@masa_id_", masa_id_);
                            command.Parameters.AddWithValue("@discount", discount);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }
                        /**/
                        using (SqlCommand command2 = new SqlCommand(updateQuery2, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command2.Parameters.AddWithValue("@masa_id_", masa_id_);

                            // Komutu çalıştır
                            command2.ExecuteNonQuery();
                        }
                        

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı güncelle
                        RefreshDataGridView3();

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
            RefreshDataGridView();
        }

        private void ikram_Click(object sender, EventArgs e)
        {
            string sip_no_id = "0";

            // DataGridView2 üzerinde seçili satırları kontrol et
            foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
            {
                // Her seçili satırdaki "Ürün Fiyatı" kolonunun değerini alın
                object cellValue = selectedRow.Cells["Siparis ID"].Value;

                // Eğer hücre değeri sayısal bir değerse toplama ekleyin
                if (cellValue != null && cellValue.ToString() != "")
                {
                    sip_no_id += "," + cellValue.ToString();
                }
            }
            textBox4.Text = sip_no_id.ToString();
            /**/
            if (dataGridView2.CurrentRow.Cells[0].Value != null)
            {

                sellect = dataGridView2.CurrentRow.Index;
            }

            else MessageBox.Show("Kayıt Bulunamadı");

            try
            {
                if (sellect != -1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // TextBox'ların içeriğini al
                        // string masa_adi_ = textBox1.Text;
                        string masa_id_ = textBox2.Text;
                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE SiparisUrun SET SiparisNo = 1 , to_offer = 1 WHERE masa_id = @masa_id_  and SiparisUrunNo in (" + sip_no_id.ToString() + ")";
                        //string updateQuery2 = "UPDATE Masalar SET masa_status = 1 WHERE masa_id = @masa_id_ ";
                         MessageBox.Show(updateQuery);
                        // MessageBox.Show(updateQuery2);
                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command.Parameters.AddWithValue("@masa_id_", masa_id_);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }
                        /*
                        using (SqlCommand command2 = new SqlCommand(updateQuery2, connection))
                        {
                            // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                            command2.Parameters.AddWithValue("@masa_id_", masa_id_);

                            // Komutu çalıştır
                            command2.ExecuteNonQuery();
                        }

                        */

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı güncelle
                        RefreshDataGridView3();

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
            RefreshDataGridView();
        }
    }
}
