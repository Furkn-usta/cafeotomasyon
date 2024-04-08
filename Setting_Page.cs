using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace restaurant_automation
{
    public partial class Setting_Page : Form
    {
        int sellect = -1;
        // public string connectionString = "Server=ENKAY;Database=ExtremeDeneme;User Id=sa;Password=3xtreme;";
        public string connectionString = connection_string.conn_string.ToString();

        public Setting_Page()
        {
            InitializeComponent();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            Order_Page app = new Order_Page();
            app.Show();
            //this.Hide();
        }
       
        private void masa_ekle_Click(object sender, EventArgs e)
        {
            masaekle mekle = new masaekle();
            mekle.Show();
            //this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Masalar mslar = new Masalar();
            mslar.Show();
            //this.Hide();
        }

        private void odeme_al_Click(object sender, EventArgs e)
        {
            siparisOdemaAlma siparisOdemaAlma = new siparisOdemaAlma(); 
            siparisOdemaAlma.Show();   
        }

        private void urun_ekle_Click(object sender, EventArgs e)
        {
            urun_ekleme urun_Ekleme = new urun_ekleme();    
            urun_Ekleme.Show();
        }

        private void kategori_Click(object sender, EventArgs e)
        {
            kategoriekle katekle = new kategoriekle();
            katekle.Show();
        }

        private void urun_recete_Click(object sender, EventArgs e)
        {
            UrunRecete urunRecete = new UrunRecete();
            urunRecete.Show();  
        }

        private void malzeme_ekle_Click(object sender, EventArgs e)
        {
            malzeme_ekle m_ekle =  new malzeme_ekle();  
            m_ekle.Show();
        }

        private void edit_user_Click(object sender, EventArgs e)
        {
            edit_user e_user = new edit_user();
            e_user.Show();
        }

        private void all_in_Click(object sender, EventArgs e)
        {
            all_in ai = new all_in();
            ai.Show();
        }
    }
}
