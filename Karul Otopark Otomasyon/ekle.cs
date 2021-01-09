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
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }
       
        private void ekle_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from parkyeri where durum=0", Kullanıcı_Girişi.baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while(okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["parkyeri"].ToString());
            }
            Kullanıcı_Girişi.baglanti.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.ToString();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("Insert Into musteri (p,marka,model,plaka,adi,soyadi,gsaat,durum) Values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + tarih.ToString() + "',0)", Kullanıcı_Girişi.baglanti);
            komut2.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("update parkyeri set durum='1' where parkyeri LIKE'"+comboBox1.Text+"'", Kullanıcı_Girişi.baglanti);
            komut3.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            MessageBox.Show("Kayıt tamamlanmıştır.", "Başarıyla tamamlandı");
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            ekle_Load(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
            string tarih = DateTime.Now.ToString();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("Insert Into musteri (p,marka,model,plaka,adi,soyadi,gsaat,durum,aracyikama) Values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + tarih.ToString() + "',0,'"+comboBox2.Text+"')", Kullanıcı_Girişi.baglanti);
            komut2.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("update parkyeri set durum='1' where parkyeri LIKE'" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
            komut3.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut4 = new OleDbCommand("Insert Into gecmis (plaka,adi,soyadi,marka,model,p,aracyikama,gsaat) Values ('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','"+comboBox2.Text+"','" + tarih.ToString() + "')", Kullanıcı_Girişi.baglanti);
            komut4.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            MessageBox.Show("Kayıt tamamlanmıştır.", "Başarıyla tamamlandı");
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            ekle_Load(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
