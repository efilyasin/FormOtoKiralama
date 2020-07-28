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
    public partial class aracbakim : Form
    {
        public aracbakim()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog=otokiralama; " +
      "Integrated Security = true; Connect Timeout = 100");
        
        void Getir()
        {

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select km,sonbakim,plaka from aracbakim ORDER BY bakimId DESC";
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
            string sorgu = "insert into aracbakim (km,sonbakim,plaka) values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Items + "')";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı Şekilde Yapılmıştır…");
            Getir();
        }

        private void aracbakim_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select distinct(plaka) from arackirala";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anasayfa frm6 = new Anasayfa();
            frm6.Show();
            this.Hide();
        }
    }
}
