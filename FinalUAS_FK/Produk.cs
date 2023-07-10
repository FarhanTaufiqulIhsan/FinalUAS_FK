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
    public partial class Produk : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtIdPro.Text = "";
            txtNamaPro.Text = "";
            txtHarga.Text = "";
            textStok.Text = "";
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            txtIdPro.Enabled = false;
            txtNamaPro.Enabled = false;
            txtHarga.Enabled = false;
            textStok.Enabled = false;
        }
        public Produk()
        {
            InitializeComponent();
        }

        private void Produk_Load(object sender, EventArgs e)
        {

        }
    }
}
