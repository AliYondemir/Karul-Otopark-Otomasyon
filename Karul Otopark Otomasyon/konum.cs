using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class konum : Form
    {
        public konum()
        {
            InitializeComponent();
        }

        private void konum_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from parkyeri,musteri where parkyeri.parkyeri=musteri.p and musteri.durum=0", Kullanıcı_Girişi.baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
               if(okuyucu["p"].ToString()=="A1")
               {
                   pictureBox1.BackColor = Color.Red;
                   label2.Text = okuyucu["plaka"].ToString();
                   label2.BackColor = Color.Red;
                   label1.BackColor = Color.Red;
              
               }
               if (okuyucu["p"].ToString() == "A2")
               {
                   pictureBox2.BackColor = Color.Red;
                   label3.Text = okuyucu["plaka"].ToString();
                   label3.BackColor = Color.Red;
                   label4.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A3")
               {
                   pictureBox4.BackColor = Color.Red;
                   label7.Text = okuyucu["plaka"].ToString();
                   label7.BackColor = Color.Red;
                   label8.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A4")
               {
                   pictureBox3.BackColor = Color.Red;
                   label5.Text = okuyucu["plaka"].ToString();
                   label5.BackColor = Color.Red;
                   label6.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A5")
               {
                   pictureBox5.BackColor = Color.Red;
                   label9.Text = okuyucu["plaka"].ToString();
                   label9.BackColor = Color.Red;
                   label10.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A10")
               {
                   pictureBox6.BackColor = Color.Red;
                   label11.Text = okuyucu["plaka"].ToString();
                   label11.BackColor = Color.Red;
                   label12.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A9")
               {
                   pictureBox7.BackColor = Color.Red;
                   label13.Text = okuyucu["plaka"].ToString();
                   label13.BackColor = Color.Red;
                   label14.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A8")
               {
                   pictureBox8.BackColor = Color.Red;
                   label15.Text = okuyucu["plaka"].ToString();
                   label15.BackColor = Color.Red;
                   label16.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A7")
               {
                   pictureBox9.BackColor = Color.Red;
                   label17.Text = okuyucu["plaka"].ToString();
                   label17.BackColor = Color.Red;
                   label18.BackColor = Color.Red;
               }
               if (okuyucu["p"].ToString() == "A6")
               {
                   pictureBox10.BackColor = Color.Red;
                   label19.Text = okuyucu["plaka"].ToString();
                   label19.BackColor = Color.Red;
                   label20.BackColor = Color.Red;
               }
            }
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
