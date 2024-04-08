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
using static restaurant_automation.Login_Page;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace restaurant_automation
{
   
    public partial class Order_Page : Form
    {
        public string UsersRecId { get; set; }
        public Order_Page()
        {
            InitializeComponent();
        }
        //OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DALYAN PC\Desktop\restaurant-automation\restaurant-automation\restaurant-automation\bin\Debug\rest-app.accdb");
        SqlConnection baglanti = new SqlConnection(connection_string.conn_string.ToString());
        
        int lastSelected =0;
         List<Shop> shops=new List<Shop>();
        double sonuc = 0;
        
        public void add_product_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Products where id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", product_id.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Shop newProduct = new Shop()
                {

                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    Adet = 1,
                    Urun = dt.Rows[0][1].ToString(),
                    Fiyat = Convert.ToDouble(dt.Rows[0][2])
                };
                var checkProduct = shops.FirstOrDefault(x => x.Id == newProduct.Id);
                if (checkProduct != null)
                {
                    checkProduct.Adet++;
                    checkProduct.Fiyat += newProduct.Fiyat;
                }
                else
                {
                    shops.Add(newProduct);
                }

                var bindingList = new BindingList<Shop>(shops);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = source;

                int i = 0;
                double toplam = Convert.ToDouble(dt.Rows[i][2]);
                sonuc += toplam;
            }

            baglanti.Close();

        }
        public void calculate_Click(object sender, EventArgs e)
        {
            double kredi = sonuc/3+1;
            textBox1.Text = Convert.ToString(sonuc);
            kredi = Math.Round(kredi, 2);
          
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) 
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) 
            {
                lastSelected =Convert.ToInt32( row.Cells[0].Value.ToString());
            }
        }
        private void Order_Page_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(ayar.user_Id.ToString()); 

            
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_SelectionChanged); 
            
            this.delete_button.Text="Ürün Sil";
            this.delete_button.Location= new Point (15, dataGridView1.Bottom + 10);
            this.decrease_button.Location= new Point (delete_button.Right+15, dataGridView1.Bottom + 10);

            this.decrease_button.Text="Ürün Azalt";
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            this.decrease_button.Click += new System.EventHandler(this.decrease_button_Click);

            this.all_delete_button.Text="Sipariş Sil";
            this.all_delete_button.Location= new Point (15, dataGridView1.Bottom + 10);
            this.all_delete_button.Location= new Point (delete_button.Right+140, dataGridView1.Bottom + 10);
            
        }
        private void delete_button_Click(object sender, EventArgs e)
        {
            
            if(lastSelected==0)
                MessageBox.Show("Lütfen Bir Ürün Seçiniz");
            else{
                var deletedshop=shops.FirstOrDefault(x=>x.Id==lastSelected);
                if(deletedshop!=null){
                    shops.Remove(deletedshop);
                    var bindingList = new BindingList<Shop>(shops);
                    var source = new BindingSource(bindingList, null);
                    dataGridView1.DataSource = source;
                }
            }
       
        }
        private void all_delete_button_Click (object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text="";
            product_id.Text="";
        }

        private void decrease_button_Click(object sender, EventArgs e)
        {
            if(lastSelected==0)
                MessageBox.Show("Lütfen Bir Ürün Seçiniz.");
            else{
                var deletedshop=shops.FirstOrDefault(x=>x.Id==lastSelected);
                if(deletedshop!=null){
                    deletedshop.Adet--;
                        if(deletedshop.Adet==0)
                            shops.Remove(deletedshop);
                    var bindingList = new BindingList<Shop>(shops);
                    var source = new BindingSource(bindingList, null);
                    dataGridView1.DataSource = source;
                }
          
            }
        }
        private void soup_button_Click(object sender, EventArgs e)
        {
            
            /*
            soup_button.BackColor = Color.LightSalmon;
            meat_button.BackColor = Color.DarkCyan;
            chicken_button.BackColor = Color.DarkCyan;
            burger_button.BackColor = Color.DarkCyan;
            pizza_button.BackColor = Color.DarkCyan;
            drink_button.BackColor = Color.DarkCyan;
            */
            soup_panel.Visible = true;
            meat_panel.Visible = false;
            chicken_panel.Visible = false;
            burger_panel.Visible = false;
            pizza_panel.Visible = false;
            drink_panel.Visible = false;
            panel3.Visible = false;
        }

        private void meat_button_Click(object sender, EventArgs e)
        {
            /*
            meat_button.BackColor = Color.LightSalmon;
            soup_button.BackColor = Color.DarkCyan;
            chicken_button.BackColor = Color.DarkCyan;
            burger_button.BackColor = Color.DarkCyan;
            pizza_button.BackColor = Color.DarkCyan;
            drink_button.BackColor = Color.DarkCyan;
            */
            soup_panel.Visible = false;
            meat_panel.Visible = true;
            chicken_panel.Visible = false;
            burger_panel.Visible = false;
            pizza_panel.Visible = false;
            drink_panel.Visible = false;
            panel3.Visible = false;
        }

        private void chicken_button_Click(object sender, EventArgs e)
        {
            /*
            chicken_button.BackColor = Color.LightSalmon;
            meat_button.BackColor = Color.DarkCyan;
            soup_button.BackColor = Color.DarkCyan;
            burger_button.BackColor = Color.DarkCyan;
            pizza_button.BackColor = Color.DarkCyan;
            drink_button.BackColor = Color.DarkCyan;
            */
            soup_panel.Visible = false;
            meat_panel.Visible = false;
            chicken_panel.Visible = true;
            burger_panel.Visible = false;
            pizza_panel.Visible = false;
            drink_panel.Visible = false;
            panel3.Visible = false;
        }

        private void pizza_button_Click(object sender, EventArgs e)
        {
            /*
            meat_button.BackColor = Color.DarkCyan;
            soup_button.BackColor = Color.DarkCyan;
            chicken_button.BackColor = Color.DarkCyan;
            burger_button.BackColor = Color.DarkCyan;
            pizza_button.BackColor = Color.LightSalmon;
            drink_button.BackColor = Color.DarkCyan;
            */
            soup_panel.Visible = false;
            meat_panel.Visible = false;
            chicken_panel.Visible = false;
            burger_panel.Visible = false;
            pizza_panel.Visible = true;
            drink_panel.Visible = false;
            panel3.Visible = false;
        }

        private void burger_button_Click(object sender, EventArgs e)
        {
            /*
            meat_button.BackColor = Color.DarkCyan;
            soup_button.BackColor = Color.DarkCyan;
            chicken_button.BackColor = Color.DarkCyan;
            burger_button.BackColor = Color.LightSalmon;
            pizza_button.BackColor = Color.DarkCyan;
            drink_button.BackColor = Color.DarkCyan;
            */
            soup_panel.Visible = false;
            meat_panel.Visible = false;
            chicken_panel.Visible = false;
            burger_panel.Visible = true;
            pizza_panel.Visible = false;
            drink_panel.Visible = false;
            panel3.Visible = false;
        }

        private void drink_button_Click(object sender, EventArgs e)
        {
            /*
            meat_button.BackColor = Color.DarkCyan;
            soup_button.BackColor = Color.DarkCyan;
            chicken_button.BackColor = Color.DarkCyan;
            burger_button.BackColor = Color.DarkCyan;
            pizza_button.BackColor = Color.DarkCyan;
            drink_button.BackColor = Color.LightSalmon;
            */
            soup_panel.Visible = false;
            meat_panel.Visible = false;
            chicken_panel.Visible = false;
            burger_panel.Visible = false;
            pizza_panel.Visible = false;
            drink_panel.Visible = true;
            panel3.Visible = false;
        }        
        
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ödeme Peşin Yapıldı");
            dataGridView1.Rows.Clear();
            textBox1.Text="";
            product_id.Text="";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ödeme Kredi Kartı İle Yapıldı");
            dataGridView1.Rows.Clear();
            textBox1.Text="";
            product_id.Text="";
        }

        private void masa_button_Click(object sender, EventArgs e)
        {
            Masalar masa = new Masalar();
            masa.Show();
            //this.Hide();
        }
    }
    public class Shop{
        public int Id { get; set; }
        public string Urun { get; set; }
        public int Adet { get; set; }
        public double Fiyat { get; set; }
    }
}
