using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sqlhospital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Z-33-3;Initial Catalog=hospital;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand();
            //komut.Connection = baglanti;
            //komut.CommandType = CommandType.StoredProcedure;
            //komut.CommandText = "kullaniciEkle";
            //baglanti.Open();
            //komut.Parameters.AddWithValue("kullaniciAd", textBox1.Text);//personelad @ li değerden geliyor prosedurlerdeki alanlarla aynı olmalı
            //komut.Parameters.AddWithValue("sifre", textBox2.Text);
            Menü menü  = new Menü();
            menü.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "kullaniciEkle";
            baglanti.Open();
            komut.Parameters.AddWithValue("kullaniciAd", textBox3.Text);//personelad @ li değerden geliyor prosedurlerdeki alanlarla aynı olmalı
            komut.Parameters.AddWithValue("sifre", textBox4.Text);
            komut.Parameters.AddWithValue("email", textBox5.Text);
            komut.Parameters.AddWithValue("telefon", maskedTextBox1.Text);

        }
    }
}
