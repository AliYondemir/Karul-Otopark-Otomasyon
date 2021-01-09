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
    public partial class gecmis : Form
    {
        public gecmis()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap=new OleDbDataAdapter ("select * from gecmis where plaka='"+textBox1.Text+"'",Kullanıcı_Girişi.baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void gecmis_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from gecmis", Kullanıcı_Girişi.baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
