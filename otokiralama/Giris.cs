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

namespace otokiralama
{
    public partial class Giris : Form
    {   
        public Giris()
        {
            InitializeComponent();
        }

        public static string bag = "Data Source =.\\SQLEXPRESS; Initial Catalog = otokiralama; Integrated Security = true;";

        private void temizle()
        {
            foreach (Control nesne in this.Controls)
            {
                if (nesne is TextBox)
                {
                    TextBox textbox = (TextBox)nesne;
                    textbox.Clear();
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string baglanti = "Data Source =.\\SQLEXPRESS; Initial Catalog = otokiralama; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(baglanti);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand sorgula = new SqlCommand("select * from admin where kullaniciadi = '" + textBox1.Text + "' and sifre='"+textBox2.Text +"'", conn);
            SqlDataReader dr = sorgula.ExecuteReader();
            if (dr.Read())
            {
                Anasayfa frm = new Anasayfa();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre yanlış…");
                temizle();
            }
        }
    }
}
    
