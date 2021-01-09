using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class Kullanıcı_Girişi : Form
    {
        public Kullanıcı_Girişi()
        {
            InitializeComponent();
        }
        public static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\PlusOtoPark.accdb");
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen giriş bilgilerini doldurunuz");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adını boş bırakmayın");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifreyi boş bırakmayın");
            }
            else
            {

                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select * From kullanici_girisi where kullanici_adi='" + textBox1.Text.ToString() + "'", baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text.ToString() == okuyucu["kullanici_adi"].ToString() && textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                        Ana_Menü anamenu = new Ana_Menü();
                        anamenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen kontrol ediniz");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen kontrol ediniz");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.google.com");
        }
    }
}
