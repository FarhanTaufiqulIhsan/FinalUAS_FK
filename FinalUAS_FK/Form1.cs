using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalUAS_FK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {

        }

        private void btnSuplier_Click(object sender, EventArgs e)
        {
            Suplier sp = new Suplier();
            sp.Show();
            this.Hide();
        }

        private void btnPenjual_Click(object sender, EventArgs e)
        {
            Penjual pj = new Penjual();
            pj.Show();
            this.Hide();
        }
    }
}
