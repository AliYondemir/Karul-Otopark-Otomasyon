﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
       
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
           
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value<100)
            {
                progressBar1.Value = progressBar1.Value + 10;
            }
            else
            {
                timer1.Enabled = false;
                Kullanıcı_Girişi kg = new Kullanıcı_Girişi();
                kg.Show();
                this.Visible = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
