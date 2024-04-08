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
    public partial class siparis_urun_ekle : Form
    {
        public siparis_urun_ekle()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        DataTable tablo3 = new DataTable();
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
                    //string selectQuery = "select isnull(M.masa_id,0) [Masa Id],isnull(M.masa_no, 0)[Masa No],case when isnull(M.masa_status, 0) = 1 then 'Boş' when isnull(M.masa_status,0)= 0 then 'Dolu' end[Masa Durumu] ,(select U.Name from users as U with(nolock) where U.users_id = isnull(M.masa_users, 0)) [Masa Oluşturan] from Masalar as M with(nolock) where M.masa_status=1 order by M.masa_id asc";
                    string selectQuery  = "select isnull(M.masa_id,0) [Masa Id],isnull(M.masa_no, 0)[Masa No],case when isnull(M.masa_status, 0) = 1 then 'Boş' when isnull(M.masa_status,0)= 0 then 'Dolu' end[Masa Durumu] ,(select U.Name from users as U with(nolock) where U.users_id = isnull(M.masa_users, 0)) [Masa Oluşturan] from Masalar as M with(nolock) where M.masa_status=0 order by M.masa_id asc";

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
        private void RefreshDataGridView2()
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

        static string ReverseText(string text)
        {
            // Metni char dizisine çevir
            char[] charArray = text.ToCharArray();

            // Char dizisini tersine çevir
            Array.Reverse(charArray);

            // Tersine çevrilmiş char dizisini stringe çevir ve döndür
            return new string(charArray);
        }

        private void RefreshDataGridView3()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string masa_adi_ = textBox1.Text;
                    string masa_id_ = textBox3.Text;
                    connection.Open();
                    // Veritabanındaki tüm kullanıcıları çeken sorgu
                    //string selectQuery = "SELECT * FROM SiparisUrun WITH (NOLOCK) ";

                    string selectQuery = " select isnull(su.SiparisUrunNo,0) [Siparis ID] ,isnull(p.pName,'') [Ürün Adı],isnull(m.masa_no,'') [Masa Adı], isnull(p.price,0) [Ürün Fiyatı]  ";
                    selectQuery += " from dbo.SiparisUrun su with (nolock) ";
                    selectQuery += " left join Masalar m with (nolock) on m.masa_id=su.masa_id ";
                    selectQuery += " left join Products p with (nolock) on p.id=su.UrunNo";
                    selectQuery += " where su.masa_id=\'" + masa_id_.ToString() + "\' and isnull(su.is_products_canceled,0)=0 and  isnull(SiparisNo,0)=0 and m.masa_no=\'" + masa_adi_.ToString() + "\'";

                    /*
                    string selectQuery = "select isnull(su.SiparisUrunNo,0) [Sipariş No],isnull(m.masa_no,'') [Masa No],isnull(UrunAdet,0)[Ürün Adeti],isnull(pName,'')[Ürün Adı],isnull(price,0) [Ürün Fiyatı] from dbo.SiparisUrun su WITH (NOLOCK) ";
                    selectQuery += " left join Masalar m WITH (NOLOCK) on m.masa_id=su.masa_id ";
                    selectQuery += " left join Products p WITH (NOLOCK) on p.id=su.UrunNo ";
                    selectQuery += " where su.masa_id=\'" + masa_id_.ToString() + "\' and m.masa_status=1 and is_products_canceled = 0 and isnull(SiparisNo,0)=0";
                   
                    connection.Open();
                     */


                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Yeni bir DataTable oluştur
                            DataTable newDataTable = new DataTable();

                            // Verileri SqlDataAdapter ile çek ve yeni DataTable'a ekle
                            adapter.Fill(newDataTable);

                            // DataGridView'ın DataSource'unu yeni DataTable ile güncelle
                            dataGridView3.DataSource = newDataTable;

                            // DataTable'ı tablo değişkenine atayarak genel tablo güncellenmiş olur
                            tablo3 = newDataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siparis_urun_ekle_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    user_info_query = "select isnull(M.masa_id,0) [Masa Id],isnull(M.masa_no, 0)[Masa No],case when isnull(M.masa_status, 0) = 1 then 'Boş' when isnull(M.masa_status,0)= 0 then 'Dolu' end[Masa Durumu] ,(select U.Name from users as U with(nolock) where U.users_id = isnull(M.masa_users, 0)) [Masa Oluşturan] from Masalar as M with(nolock) where M.masa_status=0 order by M.masa_id asc";
                    
                   
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    user_info_query = "SELECT isnull(id,0) [ID], isnull(pName,0) [Ürün Adı], isnull(price,0) [Fiyat] ,isnull(piece,0) [Adet],(select isnull(category_name,'') from Category C with (nolock) where C.category_id=P.category_id)[Kategori] FROM Products P WITH (NOLOCK)";

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

                    int rowCount = tablo2.Rows.Count;
                    // MessageBox.Show($"Toplam {rowCount} kayıt döndü.");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void masa_sec_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                /*
                dataGridView1.Enabled = false;
                dataGridView2.Enabled = true;
                */
                sellect = dataGridView1.CurrentRow.Index;
            }
            else MessageBox.Show("Kayıt Bulunamadı");

            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        string masa_adi_ = textBox1.Text;
                        string masa_id_ = textBox3.Text;
                        connection.Open();

                        user_info_query = " select isnull(su.SiparisUrunNo,0) [Siparis ID] ,isnull(p.pName,'') [Ürün Adı],isnull(m.masa_no,'') [Masa Adı], isnull(p.price,0) [Ürün Fiyatı]  ";
                        user_info_query += " from dbo.SiparisUrun su with (nolock) ";
                        user_info_query += " left join Masalar m with (nolock) on m.masa_id=su.masa_id ";
                        user_info_query += " left join Products p with (nolock) on p.id=su.UrunNo";
                        user_info_query += " where su.masa_id=\'" + masa_id_.ToString() + "\' and isnull(su.is_products_canceled,0)=0 and  isnull(SiparisNo,0)=0 and m.masa_no=\'" + masa_adi_.ToString() + "\'";

                        //MessageBox.Show(user_info_query);
                        SqlCommand command = new SqlCommand(user_info_query, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable tablo3 = new DataTable();

                        // SqlDataReader'dan gelen sütun isimlerini al
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);

                            // Eğer DataTable'da bu isimde bir sütun yoksa ekle
                            if (!tablo3.Columns.Contains(columnName))
                            {
                                tablo3.Columns.Add(columnName, typeof(string));
                            }
                        }

                        while (reader.Read())
                        {
                            // Her bir satırdaki verileri DataTable'a ekleyebilirsiniz
                            object[] values = new object[reader.FieldCount];
                            reader.GetValues(values);
                            tablo3.Rows.Add(values);
                            dataGridView3.DataSource = tablo3;

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void urun_ekle_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Cells[0].Value != null)
            {
                textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox6.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox7.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                sellect = dataGridView2.CurrentRow.Index;
            }
            else MessageBox.Show("Kayıt Bulunamadı");


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string masa_id_ = textBox3.Text;
                    string urunNo = textBox4.Text;
                    string urunAdet = textBox7.Text;

                    string insertQuery = "INSERT INTO SiparisUrun (SiparisTarih,masa_id, UrunNo, UrunAdet, personel_order_id,after_add_prod) VALUES (getdate(),@masa_id, @urunNo, @urunAdet,\'" + ayar.user_Id.ToString() + "\',1)";

                    // SqlCommand oluştur
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağla
                        command.Parameters.AddWithValue("@masa_id", masa_id_);
                        command.Parameters.AddWithValue("@urunNo", urunNo);
                        command.Parameters.AddWithValue("@urunAdet", urunAdet);
                        //command.Parameters.AddWithValue("@price", price);

                        // Komutu çalıştır
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* */
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    string masa_adi_ = textBox1.Text;
                    string masa_id_ = textBox3.Text;
                    connection.Open();
                    /*
                    user_info_query = " select isnull(su.SiparisUrunNo,0) [Sipariş No],isnull(m.masa_no,'') [Masa No],isnull(UrunAdet,0)[Ürün Adeti],isnull(pName,'')[Ürün Adı],isnull(price,0) [Ürün Fiyatı] from dbo.SiparisUrun su WITH (NOLOCK)  ";
                    user_info_query += " left join Masalar m WITH (NOLOCK) on m.masa_id=su.masa_id ";
                    user_info_query += " left join Products p WITH (NOLOCK) on p.id=su.UrunNo ";
                    user_info_query += " where su.masa_id=\'" + masa_id_.ToString() + "\' and is_products_canceled=0 and m.masa_status=1 and isnull(SiparisNo,0)=0";
                    */
                    user_info_query = " select isnull(su.SiparisUrunNo,0) [Siparis ID] ,isnull(p.pName,'') [Ürün Adı],isnull(m.masa_no,'') [Masa Adı], isnull(p.price,0) [Ürün Fiyatı]  ";
                    user_info_query += " from dbo.SiparisUrun su with (nolock) ";
                    user_info_query += " left join Masalar m with (nolock) on m.masa_id=su.masa_id ";
                    user_info_query += " left join Products p with (nolock) on p.id=su.UrunNo";
                    user_info_query += " where su.masa_id=\'" + masa_id_.ToString() + "\' and isnull(su.is_products_canceled,0)=0 and  isnull(SiparisNo,0)=0 and m.masa_no=\'" + masa_adi_.ToString() + "\'";

                    SqlCommand command = new SqlCommand(user_info_query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable tablo3 = new DataTable();

                    // SqlDataReader'dan gelen sütun isimlerini al
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);

                        // Eğer DataTable'da bu isimde bir sütun yoksa ekle
                        if (!tablo3.Columns.Contains(columnName))
                        {
                            tablo3.Columns.Add(columnName, typeof(string));
                        }
                    }

                    while (reader.Read())
                    {
                        // Her bir satırdaki verileri DataTable'a ekleyebilirsiniz
                        object[] values = new object[reader.FieldCount];
                        reader.GetValues(values);
                        tablo3.Rows.Add(values);
                        dataGridView3.DataSource = tablo3;

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
            RefreshDataGridView();
        }

        private void urun_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow.Cells[0].Value != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Silme sorgusu
                        string deleteQuery = "DELETE FROM SiparisUrun WHERE SiparisUrunNo = @SiparisUrunNo";

                        // Seçili satırın kimliğini al
                        string SiparisUrunNo = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                        // SqlCommand oluştur
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            // Parametreyi ekleyerek SQL injection saldırılarına karşı koruma sağlar
                            command.Parameters.AddWithValue("@SiparisUrunNo", SiparisUrunNo);

                            // Komutu çalıştır
                            command.ExecuteNonQuery();
                        }

                        // Veritabanındaki verileri güncelledikten sonra DataGridView'ı günceller
                        RefreshDataGridView3();

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
            /**/
        }

        private void urun_list_Click(object sender, EventArgs e)
        {
            RefreshDataGridView3();
        }

        private void sip_tamamla_Click(object sender, EventArgs e)
        {
            /* 
             Eklenen Ürünlerin stoktan düşülmesi gerekir+
             Zaten stoktan düşen ürünler için ekstra işlem yapılmayacak+
             SQL kontrol edilecek Çıkan farka göre stokdan düşülecek+
             * */
            {
                // Sipariş Numaralarını içerecek bir StringBuilder oluştur
                StringBuilder siparisNumaralari = new StringBuilder();

                // dataGridView3 içinde dön ve Sipariş No sütunundaki verileri al
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells["Siparis ID"].Value != null)
                    {
                        // Sipariş No'yu StringBuilder'a ekle
                        siparisNumaralari.Append(row.Cells["Siparis ID"].Value.ToString());
                        siparisNumaralari.Append(",");
                    }
                }
                //string test = siparisNumaralari
                // StringBuilder içeriğini TextBox'a ata
                string reversedText = ReverseText(siparisNumaralari.ToString());
                reversedText = reversedText.Substring(1, reversedText.Length - 1);
                reversedText = ReverseText(reversedText.ToString());
                textBox9.Text = reversedText.ToString();

                try
                {
                    if (sellect != -1)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // TextBox'ların içeriğini al

                            string masa_id = textBox3.Text;
                            // Güncelleme sorgusu
                            string updateQuery = "UPDATE Masalar SET masa_status = 0 WHERE masa_id = @masa_id";

                            // SqlCommand oluştur
                            using (SqlCommand command = new SqlCommand(updateQuery, connection))
                            {
                                // Parametreleri ekleyerek SQL injection saldırılarına karşı koruma sağlar
                                command.Parameters.AddWithValue("@masa_id", masa_id);

                                // Komutu çalıştır
                                command.ExecuteNonQuery();
                            }
                            /*
                            string updateQuery2 = "update Products set piece=piece-(select count(PS.pName) from Products PS with (nolock) where PS.id=P.id group by PS.pName) ";
                            updateQuery2 += " from Products P with (nolock) ";
                            updateQuery2 += " left join SiparisUrun S with (nolock) on S.UrunNo=P.id";
                            updateQuery2 += " where S.SiparisUrunNo in ("+ reversedText.ToString() + ")";
                            */
                            string updateQuery2 = "update Products set piece=piece-(select count(pName)from SiparisUrun s with (nolock)  ";
                            updateQuery2 += "  left join Products p with (nolock)  on s.UrunNo=p.id";
                            updateQuery2 += "  left join Category c with (nolock)  on c.category_id = p.category_id";
                            updateQuery2 += "  where SiparisUrunNo in (" + reversedText.ToString() + ") and isnull(s.after_add_prod,0) = 1  and p.id=P.id group by id)";
                            updateQuery2 += " from Products P with (nolock) ";
                            updateQuery2 += " left join SiparisUrun S with (nolock) on S.UrunNo=P.id";
                            updateQuery2 += " where S.SiparisUrunNo in (" + reversedText.ToString() + ")";
                            updateQuery2 += " and isnull(S.after_add_prod,0) = 1   and (select p.id  from SiparisUrun s with (nolock) ";
                            updateQuery2 += "  left join Products p with (nolock)  on s.UrunNo=p.id";
                            updateQuery2 += "  left join Category c with (nolock)  on c.category_id = p.category_id";
                            updateQuery2 += "  where SiparisUrunNo in (" + reversedText.ToString() + ")";
                            updateQuery2 += " and isnull(s.after_add_prod,0) = 1  and p.id=P.id group by id) = P.id ";

                            using (SqlCommand command2 = new SqlCommand(updateQuery2, connection))
                            {

                                // Komutu çalıştır
                                command2.ExecuteNonQuery();
                            }
                            // Veritabanındaki verileri güncelledikten sonra DataGridView'ı güncelle
                            RefreshDataGridView();

                            MessageBox.Show("Sipariş Başarıyla Alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                RefreshDataGridView2();

            }
        }
    }
}
