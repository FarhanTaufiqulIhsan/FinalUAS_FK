using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalUAS_FK
{
    public partial class JenisProduk : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            cbxIdp.Enabled = false;
            txtHp.Enabled = false;
            txtMp.Enabled = false;
            txtNjp.Enabled = false;
            txtHp.Text = "";
            txtMp.Text = "";
            txtNjp.Text = "";
        }
        public JenisProduk()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Produk p = new Produk();
            p.Show();
            this.Hide();
        }

        private void JenisProduk_Load(object sender, EventArgs e)
        {

        }
    }
}
