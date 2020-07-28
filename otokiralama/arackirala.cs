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
    public partial class arackirala : Form
    {
        public arackirala()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog=otokiralama; " +
       "Integrated Security = true; Connect Timeout = 100");


        void musterigetir()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select * from musteri ORDER BY musteriId DESC";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        void aracgetir()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select * from arackirala ORDER BY aracId DESC";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void BtnMusteriGetir_Click(object sender, EventArgs e)
        {

            musterigetir();

        }

        private void BtnAracGetir_Click(object sender, EventArgs e)
        {
            aracgetir();
        }

        private void arackirala_Load(object sender, EventArgs e)
        {
            

        }
        void Getir()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select kimlikno,ad,soyad,plaka,atarihi,ttarihi from kirala ORDER BY kiralaId DESC";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "insert into kirala (kimlikno,ad,soyad,plaka,atarihi,ttarihi) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "')";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı Şekilde Yapılmıştır…");
            Getir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
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

            string sorgu = "delete from kirala where plaka='" + textBox4.Text + "'";

            if (Sorgula(textBox1.Text))
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.ExecuteNonQuery();
                Getir();
                MessageBox.Show("İşlem Başarılı");
            }
            else
            {
                MessageBox.Show("Bu plakada araç yok");
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa frm6 = new Anasayfa();
            frm6.Show();
            this.Hide();
        }
    }
}
