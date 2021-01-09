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
    public partial class araccikis : Form
    {
        public araccikis()
        {
            InitializeComponent();
        }

        private void araccikis_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from musteri where durum=0", Kullanıcı_Girişi.baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["plaka"].ToString());
            }
            Kullanıcı_Girişi.baglanti.Close();
        }
        DateTime tarih;
        string parkyeri = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double aracyikama = 0;
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("Select * from musteri where durum=0 and plaka LIKE'"+comboBox1.Text+"'", Kullanıcı_Girişi.baglanti);
            OleDbDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                label3.Text = okuyucu2["marka"].ToString();
                label4.Text = okuyucu2["model"].ToString();
                label6.Text = okuyucu2["adi"].ToString();
                label8.Text = okuyucu2["soyadi"].ToString();
                tarih = Convert.ToDateTime(okuyucu2["gsaat"].ToString());
                parkyeri = okuyucu2["p"].ToString();
                label12.Text = okuyucu2["aracyikama"].ToString();
            }
            if (label12.Text=="Var")
            {
                aracyikama = 15;
            }
            else if (label12.Text=="Yok")
            {
                aracyikama = 0;
            }
            Kullanıcı_Girişi.baglanti.Close();
            System.TimeSpan zaman;
            DateTime sondeger = DateTime.Now;
            zaman = sondeger.Subtract(tarih);
            double saat = Convert.ToDouble(zaman.TotalHours);
            double para = 2 * double.Parse(saat.ToString("0.##"));
            label11.Text = (aracyikama + para).ToString()+" TL";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut4 = new OleDbCommand("update parkyeri set durum=0 where parkyeri='"+parkyeri+"'", Kullanıcı_Girişi.baglanti);
            komut4.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut5 = new OleDbCommand("update musteri set durum=1 where plaka='" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
            komut5.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            OleDbCommand komut6 = new OleDbCommand("update gecmis set csaat='"+DateTime.Now+"', fiyat='"+label11.Text+"' where plaka='"+comboBox1.Text+"'", Kullanıcı_Girişi.baglanti);
            komut6.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            MessageBox.Show("Araç çıkışı yapılmıştır.", "Başarıyla tamamlandı");
            parkyeri = "";
            label3.Text = "";
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
            comboBox1.Text = "";
            label11.Text = "";
            label12.Text = "";
            comboBox1.Items.Clear();
            araccikis_Load(sender, e);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
