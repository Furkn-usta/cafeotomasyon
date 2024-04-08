using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant_automation
{

    public partial class Welcome_Page : Form
    {
        public Welcome_Page()
        {
            InitializeComponent();
            InitializeConnectionString();
        }

        private static void InitializeConnectionString()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db.txt");
           // MessageBox.Show(filePath);
            if (File.Exists(filePath))
            {
                // db.txt dosyası varsa, bağlantı bilgilerini oku
                try
                {
                    connection_string.conn_string = File.ReadAllText(filePath);
                   // MessageBox.Show("Bağlantı bilgileri başarıyla okundu:\n" + connection_string.conn_string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı bilgileri okuma hatası: " + ex.Message);
                }
            }
            else
            {
                // db.txt dosyası yoksa, yeni bilgileri giriş yaparak oluştur
                MessageBox.Show("db.txt dosyası bulunamadı. Yeni bağlantı bilgilerini giriniz:");

                // Yeni form oluştur
                Form form = new Form();
                form.Text = "Bağlantı Bilgileri";
                form.Size = new System.Drawing.Size(300, 200);

                Label lblServer = new Label();
                lblServer.Text = "Server Adı:";
                lblServer.Location = new System.Drawing.Point(20, 20);
                form.Controls.Add(lblServer);

                TextBox txtServer = new TextBox();
                txtServer.Location = new System.Drawing.Point(120, 20);
                form.Controls.Add(txtServer);

                Label lblDatabase = new Label();
                lblDatabase.Text = "Database Adı:";
                lblDatabase.Location = new System.Drawing.Point(20, 50);
                form.Controls.Add(lblDatabase);

                TextBox txtDatabase = new TextBox();
                txtDatabase.Location = new System.Drawing.Point(120, 50);
                form.Controls.Add(txtDatabase);

                Label lblUserId = new Label();
                lblUserId.Text = "User Id:";
                lblUserId.Location = new System.Drawing.Point(20, 80);
                form.Controls.Add(lblUserId);

                TextBox txtUserId = new TextBox();
                txtUserId.Location = new System.Drawing.Point(120, 80);
                form.Controls.Add(txtUserId);

                Label lblPassword = new Label();
                lblPassword.Text = "Password:";
                lblPassword.Location = new System.Drawing.Point(20, 110);
                form.Controls.Add(lblPassword);

                TextBox txtPassword = new TextBox();
                txtPassword.Location = new System.Drawing.Point(120, 110);
                txtPassword.PasswordChar = '*';
                form.Controls.Add(txtPassword);

                Button btnOK = new Button();
                btnOK.Text = "OK";
                btnOK.Location = new System.Drawing.Point(40, 140);
                btnOK.Click += (sender, e) =>
                {
                    connection_string.conn_string = $"Server={txtServer.Text};Database={txtDatabase.Text};User Id={txtUserId.Text};Password={txtPassword.Text};";
                    try
                    {
                        File.WriteAllText(filePath, connection_string.conn_string);
                        MessageBox.Show("Yeni bağlantı bilgileri başarıyla db.txt dosyasına yazıldı:\n" + connection_string.conn_string);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bağlantı bilgileri yazma hatası: " + ex.Message);
                    }
                    form.Close();
                };
                form.Controls.Add(btnOK);
                form.FormClosing += (sender, e) =>
                {
                    if (string.IsNullOrEmpty(connection_string.conn_string))
                    {
                        if (MessageBox.Show("Bağlantı bilgileri girilmedi, programı kapatmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Application.Exit(); // Uygulamayı kapat
                        }
                        else
                        {
                            e.Cancel = true; // Form kapatılmasını iptal et
                          //  InitializeConnectionString(); // Bağlantı bilgileri formunu tekrar göster
                        }
                    }
                };
                form.ShowDialog();
                //db dosyasını şifreleme eklenecek 29.02.2024 23:45
            }
        }



        private void admin_login_Click(object sender, EventArgs e)
        {
            /*
            Setting_Page app = new Setting_Page();
            app.Show();
            this.Hide();
            ----Bakımda
             */
            MessageBox.Show("Şuan Bakım Aşamasındayız");
           // this.Hide();
            Application.Exit();

        }

        private void worker_login_Click(object sender, EventArgs e)
        {
            Login_Page app = new Login_Page();
            app.Show();
            this.Hide();
        }

       
    }

}
