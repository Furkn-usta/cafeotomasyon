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
    public partial class Login_Page : Form
    {
        //public string connectionString = "Server=ENKAY;Database=ExtremeDeneme;User Id=sa;Password=3xtreme;";
        public string connectionString = connection_string.conn_string.ToString();

        string user_control_query = "";
        //public string users_rec_Id_1 = "";
        public Login_Page()
        {
            InitializeComponent();
        }

        private void Login_Page_Load(object sender, EventArgs e)
        {
            // Burada SqlConnection nesnesi tanımlamaya gerek yok, zaten sınıf özelliği olarak tanımlanmış.
        }

        private void Login_button_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string username = user_name.Text;
                    string password = pass_word.Text;

                    user_control_query = "SELECT TOP 1 ISNULL(U.users_id, 0) AS users_Id FROM users AS U WITH (NOLOCK) WHERE ISNULL(U.Username, '') = @username AND ISNULL(U.Password, '') = @password";

                    SqlCommand command = new SqlCommand(user_control_query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = command.ExecuteReader();
                    

                    if (reader.Read())
                    {
                        //users_rec_Id_1 = reader["users_Id"].ToString();
                       ayar.user_Id = Convert.ToInt16(reader["users_Id"]); 
                        

                        if (reader["users_Id"].ToString() == "3")
                        {
                            Setting_Page app = new Setting_Page();
                            app.Show();
                            this.Hide();
                            
                        }
                        else
                        {
                            Setting_Page app = new Setting_Page();
                           // app.UsersRecId = reader["users_Id"].ToString();
                            app.Show();
                            this.Hide();
                            
                        }
                        /*
                        string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                        MessageBox.Show(currentDirectory);
                          */
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz kullanıcı adı veya şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void user_name_TextChanged(object sender, EventArgs e)
        {
            // Eğer kullanıcı adı değişirse burada yapılacak işlemler.
        }

    }
}

