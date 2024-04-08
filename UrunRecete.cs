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
    public partial class UrunRecete : Form
    {
        public UrunRecete()
        {
            InitializeComponent();
            LoadMalzeme();
            LoadUrun();
        }
        TextBox[] textBoxes;
        TextBox[] textBoxes1;
        TextBox[] textBoxes2;
        TextBox[] textBoxes3;
        TextBox[] textBoxes4;
        TextBox[] textBoxes5;
        int secilenSayisi;
        DataTable tablo = new DataTable();
        //public string connectionString = "Server=ENKAY;Database=ExtremeDeneme;User Id=sa;Password=3xtreme;";
        public string connectionString = connection_string.conn_string.ToString();

        //int sellect = -1;
        private void LoadMalzeme()
        {
            string query = "SELECT malzeme_adi,id FROM Malzemeler with (nolock)";
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
                            string malzemeName = reader["malzeme_adi"].ToString();
                            checkedListBox1.Items.Add(malzemeName);
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
        private string ChooseMalzeme(string mal)
        {
            string malzemebirim = ""; // Malzemenin birim bilgisini tutacak değişken
           
            string query = "SELECT isnull(birim,'') birim FROM Malzemeler with (nolock) WHERE malzeme_adi = @mal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Parametre ekleyerek SQL injection saldırılarına karşı koruma sağla
                        command.Parameters.AddWithValue("@mal", mal);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            malzemebirim = reader["birim"].ToString();
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

            return malzemebirim;
        }
        private string ChooseMalzemeAdet(string mal)
        {
            string  malzemeAdetMik = "0"; // Malzemenin birim bilgisini tutacak değişken

            string query = "SELECT isnull(adet_gramaj,0) adet_gramaj FROM Malzemeler with (nolock) WHERE malzeme_adi = @mal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Parametre ekleyerek SQL injection saldırılarına karşı koruma sağla
                        command.Parameters.AddWithValue("@mal", mal);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            malzemeAdetMik = reader["adet_gramaj"].ToString();
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

            return malzemeAdetMik;
        }

        private void LoadUrun()
        {
            string query = "SELECT pName FROM Products with (nolock)";
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
                            string urun_name = reader["pName"].ToString();
                            comboBox1.Items.Add(urun_name);
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


        public void urunleri_getir_Click(object sender, EventArgs e)
        {

            secilenSayisi = checkedListBox1.CheckedItems.Count;
            textBoxes = new TextBox[secilenSayisi];  // Kullanılan Miktar
            textBoxes1 = new TextBox[secilenSayisi]; // Birim Fiyat
            textBoxes2 = new TextBox[secilenSayisi]; // Fire1
            textBoxes3 = new TextBox[secilenSayisi]; // Fire2
            textBoxes4 = new TextBox[secilenSayisi]; // Hesaplanan Miktar
            textBoxes5 = new TextBox[secilenSayisi]; // Hesaplanan Miktar
            for (int i = 0; i < secilenSayisi; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes1[i] = new TextBox();
                textBoxes2[i] = new TextBox();
                textBoxes3[i] = new TextBox();
                textBoxes4[i] = new TextBox();
                textBoxes5[i] = new TextBox();
                TextBox yeniTextBox1 = new TextBox();

                yeniTextBox1.Name = "textBoxF_" + (i + 1).ToString(); // Her TextBox için benzersiz bir isim belirle
                yeniTextBox1.Text = "0"; // İsteğe bağlı: Varsayılan metni ayarla

                // Oluşturulan TextBox'ı formun kontrol koleksiyonuna ekle
                this.Controls.Add(yeniTextBox1);
                textBoxes1[i] = yeniTextBox1;
                // İsteğe bağlı olarak, TextBox'ların konumunu ve boyutunu ayarla
                yeniTextBox1.Location = new Point(320, 70 + i * 30);
                yeniTextBox1.Size = new Size(90, 20);
            }
            /*Fire1*/
            for (int i = 0; i < secilenSayisi; i++)
            {

                TextBox yeniTextBox2 = new TextBox();

                yeniTextBox2.Name = "textBoxW1_" + (i + 1).ToString(); // Her TextBox için benzersiz bir isim belirle
                yeniTextBox2.Text = "0 "; // İsteğe bağlı: Varsayılan metni ayarla

                // Oluşturulan TextBox'ı formun kontrol koleksiyonuna ekle
                this.Controls.Add(yeniTextBox2);
                textBoxes2[i] = yeniTextBox2;
                // İsteğe bağlı olarak, TextBox'ların konumunu ve boyutunu ayarla
                yeniTextBox2.Location = new Point(420, 70 + i * 30);
                yeniTextBox2.Size = new Size(45, 20);
            }
            /*Fire2*/
            for (int i = 0; i < secilenSayisi; i++)
            {

                TextBox yeniTextBox3 = new TextBox();

                yeniTextBox3.Name = "textBoxW2_" + (i + 1).ToString(); // Her TextBox için benzersiz bir isim belirle
                yeniTextBox3.Text = "0 "; // İsteğe bağlı: Varsayılan metni ayarla

                // Oluşturulan TextBox'ı formun kontrol koleksiyonuna ekle
                this.Controls.Add(yeniTextBox3);
                textBoxes3[i] = yeniTextBox3;
                // İsteğe bağlı olarak, TextBox'ların konumunu ve boyutunu ayarla
                yeniTextBox3.Location = new Point(480, 70 + i * 30);
                yeniTextBox3.Size = new Size(45, 20);
            }
            /*Hesaplanan*/
            for (int i = 0; i < secilenSayisi; i++)
            {

                TextBox yeniTextBox4 = new TextBox();

                yeniTextBox4.Name = "textBoxH1_" + (i + 1).ToString(); // Her TextBox için benzersiz bir isim belirle
                yeniTextBox4.Text = "0"; // İsteğe bağlı: Varsayılan metni ayarla

                // Oluşturulan TextBox'ı formun kontrol koleksiyonuna ekle
                this.Controls.Add(yeniTextBox4);
                textBoxes4[i] = yeniTextBox4;
                // İsteğe bağlı olarak, TextBox'ların konumunu ve boyutunu ayarla
                yeniTextBox4.Location = new Point(550, 70 + i * 30);
                yeniTextBox4.Size = new Size(120, 20);
            }
            /*Kar Yüzdesi*/
            for (int i = 0; i < secilenSayisi; i++)
            {

                TextBox yeniTextBox5 = new TextBox();

                yeniTextBox5.Name = "textBoxK1_" + (i + 1).ToString(); // Her TextBox için benzersiz bir isim belirle
                yeniTextBox5.Text = "0"; // İsteğe bağlı: Varsayılan metni ayarla

                // Oluşturulan TextBox'ı formun kontrol koleksiyonuna ekle
                this.Controls.Add(yeniTextBox5);
                textBoxes5[i] = yeniTextBox5;
                // İsteğe bağlı olarak, TextBox'ların konumunu ve boyutunu ayarla
                yeniTextBox5.Location = new Point(710, 70 + i * 30);
                yeniTextBox5.Size = new Size(50, 20);
            }
            //MessageBox.Show(secilenSayisi.ToString());
            for (int i = 0; i < secilenSayisi; i++)
            {
                string birim_ = ChooseMalzeme(checkedListBox1.CheckedItems[i].ToString());

                TextBox yeniTextBox = new TextBox();
                Label yeniLabel = new Label();
                yeniLabel.Text = checkedListBox1.CheckedItems[i].ToString() + " :";
                yeniLabel.Name = "label" + (i + 1).ToString();
                yeniLabel.ForeColor = Color.White;

                yeniLabel.Visible = true;

                yeniTextBox.Name = "textBox_" + (i + 1).ToString(); // Her TextBox için benzersiz bir isim belirle
                //yeniTextBox.Text = "TextBox_ " + (i + 1).ToString(); // İsteğe bağlı: Varsayılan metni ayarla
                yeniTextBox.Text = "0";
                // Oluşturulan TextBox'ı formun kontrol koleksiyonuna ekle
                this.Controls.Add(yeniTextBox);
                this.Controls.Add(yeniLabel);
                textBoxes[i] = yeniTextBox;
                // İsteğe bağlı olarak, TextBox'ların konumunu ve boyutunu ayarla
                yeniLabel.Location = new Point(140, 70 + i * 30);
                yeniTextBox.Location = new Point(205, 70 + i * 30);
                yeniTextBox.Size = new Size(90, 20);
                /*
                string tname="textBox_" + (i + 1).ToString();
                string tname1 = "textBoxH1_" + (i + 1).ToString();
                string tname2 = "textBoxW2_" + (i + 1).ToString();
                string tname3 = "textBoxW1_" + (i + 1).ToString();
                string tname4 = "textBoxF_" + (i + 1).ToString();
                MessageBox.Show(tname);
                */

                string query = "SELECT cast(isnull(birim_fiyat,0) as decimal(15,2)) birim_fiyat FROM Malzemeler as M with (nolock) where M.malzeme_adi=\'" + checkedListBox1.CheckedItems[i].ToString() + "\'";
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
                                decimal brm_fiyat = Convert.ToDecimal(reader["birim_fiyat"]);
                                textBoxes1[i].Text = brm_fiyat.ToString();
                            }//textBoxF_
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
            for (int i = 0; i < secilenSayisi; i++)
            {
                /*
                TextBox[] textBoxes = new TextBox[secilenSayisi];//Kullanılan Miktar
                TextBox[] textBoxes1 = new TextBox[secilenSayisi];//Birim Fiyat
                TextBox[] textBoxes2 = new TextBox[secilenSayisi];//Fire1
                TextBox[] textBoxes3 = new TextBox[secilenSayisi];//Fire2
                TextBox[] textBoxes4 = new TextBox[secilenSayisi];//Hesaplanan Miktar
                */
            }

        }

        private void temizle_Click(object sender, EventArgs e)
        {
            // Form üzerindeki tüm kontrol elemanlarını gez
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                // Eğer kontrol bir TextBox ise ve adı "textBox_" veya "textBoxF_" ile başlıyorsa
                if (Controls[i] is TextBox && (Controls[i].Name.StartsWith("textBox_") || Controls[i].Name.StartsWith("textBoxF_") || Controls[i].Name.StartsWith("textBoxH1_") || Controls[i].Name.StartsWith("textBoxK1_") || Controls[i].Name.StartsWith("textBoxW1_") || Controls[i].Name.StartsWith("textBoxW2_")))
                {
                    // TextBox'ı form üzerinden kaldır
                    Controls.RemoveAt(i);
                }
                // Eğer kontrol bir Label ise ve adı "label" ile başlıyorsa
                else if (Controls[i] is Label && Controls[i].Name.StartsWith("label"))
                {
                    // Label'ı form üzerinden kaldır
                    Controls.RemoveAt(i);
                }
            }
        }

        private void hesapla_Click(object sender, EventArgs e)
        {
            decimal kul_mik_ = 0;
            decimal brm_fiyat = 0;
            decimal fire_1 = 0;
            decimal fire_2 = 0;
            decimal hes_mik = 0;
            decimal kar = 0;
            decimal toplam_fiyat = 0;


            for (int i = 0; i < secilenSayisi; i++)
            {
                if (!string.IsNullOrEmpty(textBoxes[i].Text))
                {
                    kul_mik_ = Convert.ToDecimal(textBoxes[i].Text);
                }
                if (!string.IsNullOrEmpty(textBoxes1[i].Text))
                {
                    brm_fiyat = Convert.ToDecimal(textBoxes1[i].Text);
                }
                if (!string.IsNullOrEmpty(textBoxes2[i].Text))
                {
                    fire_1 = Convert.ToDecimal(textBoxes2[i].Text);
                }
                if (!string.IsNullOrEmpty(textBoxes3[i].Text))
                {
                    fire_2 = Convert.ToDecimal(textBoxes3[i].Text);
                }

                if (!string.IsNullOrEmpty(textBoxes5[i].Text))
                {
                    kar = Convert.ToDecimal(textBoxes5[i].Text);
                }
                string birim_ = ChooseMalzeme(checkedListBox1.CheckedItems[i].ToString());
                if (birim_ != "" && (birim_.ToString().ToLower() == "kg" || birim_.ToString().ToLower() == "lt"))
                {
                    hes_mik = (brm_fiyat * kul_mik_) / 1000;
                    if (Convert.ToDecimal(fire_1) != 0)
                        hes_mik = ((Convert.ToDecimal(hes_mik) * Convert.ToDecimal(fire_1)) / 100) + Convert.ToDecimal(hes_mik);
                    if (Convert.ToDecimal(fire_2) != 0)
                        hes_mik = ((Convert.ToDecimal(hes_mik) * Convert.ToDecimal(fire_2)) / 100) + Convert.ToDecimal(hes_mik);

                    // MessageBox.Show(brm_fiyat.ToString());
                    //MessageBox.Show(kul_mik_.ToString());
                }
                if (birim_ != "" && (birim_.ToString().ToLower() == "adet"))
                {
                    string adet_gramaj_ = ChooseMalzemeAdet(checkedListBox1.CheckedItems[i].ToString()).ToString();
                   
                    hes_mik = (Convert.ToDecimal(adet_gramaj_) * brm_fiyat * kul_mik_);
                   
                    if (Convert.ToDecimal(fire_1) != 0)
                        hes_mik = ((Convert.ToDecimal(hes_mik) * Convert.ToDecimal(fire_1)) / 100) + Convert.ToDecimal(hes_mik);
                    if (Convert.ToDecimal(fire_2) != 0)
                        hes_mik = ((Convert.ToDecimal(hes_mik) * Convert.ToDecimal(fire_2)) / 100) + Convert.ToDecimal(hes_mik);
                    // MessageBox.Show(brm_fiyat.ToString());
                    //MessageBox.Show(kul_mik_.ToString());

                    
                }
                if(Convert.ToDecimal(kar)!=0)
                {
                    hes_mik =(hes_mik * kar)/100 + hes_mik;
                }
                toplam_fiyat += hes_mik;
                //topfiyat_.Text = toplam_fiyat.ToString("N2");
                textBoxes4[i].Text = hes_mik.ToString("N2");
            }
            
            if (!string.IsNullOrEmpty(karoran.Text))
            {
                toplam_fiyat = (toplam_fiyat * Convert.ToDecimal(karoran.Text)) / 100 + toplam_fiyat;
                topfiyat_.Text = toplam_fiyat.ToString("N2");
            }
            else
                topfiyat_.Text = toplam_fiyat.ToString("N2");
        }
    }
}
