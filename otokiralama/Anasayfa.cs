using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otokiralama
{
    public partial class Anasayfa : Form
    {
        musterikayit frm3 = new musterikayit();
        arackayit frm4 = new arackayit();
        admin frm5 = new admin();
        Giris frm6 = new Giris();
        arackirala frm7 = new arackirala();
        aracbakim frm8 = new aracbakim();
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm6.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm7.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm8.Show();
            this.Hide();
        }
    }
}
