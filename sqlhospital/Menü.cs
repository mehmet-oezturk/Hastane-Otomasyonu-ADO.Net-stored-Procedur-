using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlhospital
{
    public partial class Menü : Form
    {
        public Menü()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           poliklinikler aa= new poliklinikler();
            aa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doktorlar aa= new doktorlar();
            aa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hastalar aa= new hastalar();
            aa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            raporlar aa=new raporlar();
            aa.Show();
            this.Hide();
        }
    }
}
