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
    public partial class poliklinikler : Form
    {
        public poliklinikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Z-33-3;Initial Catalog=hospital;Integrated Security=True");
       
        private void button1_Click(object sender, EventArgs e)
        {
            Menü menü = new Menü();
            menü.Show();
            this.Hide();
        }
        public void listele()
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "pollistele";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "pekle";
            baglanti.Open();
            komut.Parameters.AddWithValue("pAdi", textBox2.Text);//personelad @ li değerden geliyor prosedurlerdeki alanlarla aynı olmalı
            komut.Parameters.AddWithValue("pUzmanSayisi", textBox3.Text);
            komut.Parameters.AddWithValue("pBaskan", textBox4.Text);
            komut.Parameters.AddWithValue("pBasHemsire", textBox5.Text);
            komut.Parameters.AddWithValue("yatakSayisi", textBox6.Text);
            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polyenile";
            baglanti.Open();
            komut.Parameters.AddWithValue("PNo", textBox1.Text);
            komut.Parameters.AddWithValue("pAdi", textBox2.Text);//personelad @ li değerden geliyor prosedurlerdeki alanlarla aynı olmalı
            komut.Parameters.AddWithValue("pUzmanSayisi", textBox3.Text);
            komut.Parameters.AddWithValue("pBaskan", textBox4.Text);
            komut.Parameters.AddWithValue("pBasHemsire", textBox5.Text);
            komut.Parameters.AddWithValue("yatakSayisi", textBox6.Text);
            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void poliklinikler_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polza";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "pnosilme";
            baglanti.Open();
            komut.Parameters.AddWithValue("PNo", textBox9.Text);
           
            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == null)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "polara";
                baglanti.Open();
                komut.Parameters.AddWithValue("PNo", textBox8.Text);

                komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
                
                baglanti.Close();
                listele();

            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   int sectim= dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sectim].Cells[5].Value.ToString();

        }
    }
}
