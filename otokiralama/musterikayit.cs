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
    public partial class musterikayit : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog=otokiralama; " +
      "Integrated Security = true; Connect Timeout = 100");


        public musterikayit()
        {
            InitializeComponent();
            Getir();
        }
        void Getir()
        {

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select isim,soyisim,kimlikno from musteri ORDER BY musteriId DESC";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "insert into musteri (isim,soyisim,kimlikno) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı Şekilde Yapılmıştır…");
            Getir();
        }

        private void musterikayit_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            string sorgu = "update musteri set isim = '" + textBox1.Text + "', soyisim='" + textBox2.Text + "' where kimlikno= '" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            Getir();
            MessageBox.Show("İşlem Başarılı…");
            conn.Close();
        }
        bool Sorgula(string plaka)
        {

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string sorgu = "delete from musteri where kimlikno='" + textBox3.Text + "'";

            if (Sorgula(textBox1.Text))
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.ExecuteNonQuery();
                Getir();
                MessageBox.Show("İşlem Başarılı");
            }
            else
            {
                MessageBox.Show("Böyle bir müşteri yok");
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa frm6 = new Anasayfa();
            frm6.Show();
            this.Hide();
        }
    }
}
