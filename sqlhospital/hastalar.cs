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
    public partial class hastalar : Form
    {
        public hastalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Z-33-3;Initial Catalog=hospital;Integrated Security=True");
        public void listele()
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hlistele";
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

        private void hastalar_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();             
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hza";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hekle";
            baglanti.Open();
            komut.Parameters.AddWithValue("had", textBox2.Text);
            komut.Parameters.AddWithValue("htc", textBox3.Text);
            komut.Parameters.AddWithValue("dogum", textBox4.Text);
            komut.Parameters.AddWithValue("boy", textBox11.Text);
            komut.Parameters.AddWithValue("yas", textBox12.Text);
            komut.Parameters.AddWithValue("recete", textBox13.Text);
            komut.Parameters.AddWithValue("rapor", textBox14.Text);
            komut.Parameters.AddWithValue("randevu", textBox10.Text);
            komut.Parameters.AddWithValue("dno", textBox5.Text);
            
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hyenile";
            baglanti.Open();
            komut.Parameters.AddWithValue("hno", textBox1.Text);
            komut.Parameters.AddWithValue("had", textBox2.Text);
            komut.Parameters.AddWithValue("htc", textBox3.Text);
            komut.Parameters.AddWithValue("dogum", textBox4.Text);
            komut.Parameters.AddWithValue("boy", textBox11.Text);
            komut.Parameters.AddWithValue("yas", textBox12.Text);
            komut.Parameters.AddWithValue("recete", textBox13.Text);
            komut.Parameters.AddWithValue("rapor", textBox14.Text);
            komut.Parameters.AddWithValue("randevu", textBox10.Text);
            komut.Parameters.AddWithValue("dno", textBox5.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dgoster";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;

            
            textBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            textBox11.Text = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            textBox12.Text = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            textBox13.Text = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
            textBox14.Text = dataGridView1.Rows[sectim].Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.Rows[sectim].Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sectim].Cells[9].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hsilme";
            baglanti.Open();
            komut.Parameters.AddWithValue("hno", textBox9.Text);

            komut.ExecuteNonQuery();//tablomdaki değişiklikleri kaydet
            baglanti.Close();
            listele();
        }
    }
}
