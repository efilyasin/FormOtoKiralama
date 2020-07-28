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
    public partial class admin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog=otokiralama; " +
      "Integrated Security = true; Connect Timeout = 100");

        public admin()
        {
            InitializeComponent();
            Getir();
        }

        void Getir()
        {

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select kullaniciadi,sifre from admin ORDER BY Id DESC";
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
            string sorgu = "insert into admin (kullaniciadi,sifre) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı Şekilde Yapılmıştır…");
            Getir();
        }

        bool Sorgula(string plaka)
        {

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string sorgu = "delete from admin where kullaniciadi='" + textBox1.Text + "'";

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

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa frm6 = new Anasayfa();
            frm6.Show();
            this.Close();
        }
    }
}
