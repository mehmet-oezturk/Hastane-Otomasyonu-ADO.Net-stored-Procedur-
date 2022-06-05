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
    public partial class doktorlar : Form
    {
        public doktorlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Z-33-3;Initial Catalog=hospital;Integrated Security=True");
        public void listele()
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dlistele";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Menü menü = new Menü();
            menü.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dekle";
            baglanti.Open();
            komut.Parameters.AddWithValue("dAd", textBox2.Text);//personelad @ li değerden geliyor prosedurlerdeki alanlarla aynı olmalı
            komut.Parameters.AddWithValue("dTc", textBox3.Text);
            komut.Parameters.AddWithValue("uzmanlikAlani", textBox4.Text);
            komut.Parameters.AddWithValue("telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("adres", textBox6.Text);
            komut.Parameters.AddWithValue("dogum", textBox10.Text);
            komut.Parameters.AddWithValue("polNo", textBox5.Text);
            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void doktorlar_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dza";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "pnogoster";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dyenile";
            baglanti.Open();
            komut.Parameters.AddWithValue("dNo", textBox1.Text);
            komut.Parameters.AddWithValue("dAd", textBox2.Text);//personelad @ li değerden geliyor prosedurlerdeki alanlarla aynı olmalı
            komut.Parameters.AddWithValue("dTc", textBox3.Text);
            komut.Parameters.AddWithValue("uzmanlikAlani", textBox4.Text);
            komut.Parameters.AddWithValue("telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("adres", textBox6.Text);
            komut.Parameters.AddWithValue("dogum", textBox10.Text);
            komut.Parameters.AddWithValue("polNo", textBox5.Text);
            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dsilme";
            baglanti.Open();
            komut.Parameters.AddWithValue("dno", textBox9.Text);

            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim=dataGridView1.SelectedCells[0].RowIndex;

            //    string  doktorno=dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            textBox1.Text=dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sectim].Cells[7].Value.ToString();

        }
    }
    }
