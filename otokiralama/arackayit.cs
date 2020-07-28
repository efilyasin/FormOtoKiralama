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
    public partial class arackayit : Form
    {
        SqlConnection conn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog=otokiralama; " +
       "Integrated Security = true; Connect Timeout = 100");


        public arackayit()
        {
            InitializeComponent();
            Getir();
        }

        void Getir()
        {

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select plaka,marka,model,kasatipi,km,durum from arackirala ORDER BY aracId DESC";
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
            string sorgu = "insert into arackirala (plaka,marka,model,kasatipi,km,durum) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı Şekilde Yapılmıştır…");
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            string sorgu = "update arackirala set marka = '" + textBox2.Text + "', model='" + textBox3.Text + "',kasatipi= '" + textBox4.Text + "',km= '" + textBox5.Text + "', durum='" + textBox6.Text + "' where plaka= '" + textBox1.Text + "'";
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

            string sorgu = "delete from arackirala where plaka='" + textBox1.Text + "'";

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

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa frm6 = new Anasayfa();
            frm6.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
