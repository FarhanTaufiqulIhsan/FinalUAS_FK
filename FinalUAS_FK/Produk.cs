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
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT ID_Produk, Nama_Produk, Harga_Produk, Stok_Produk FROM dbo.Produk";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void Produk_Load(object sender, EventArgs e)
        {

        }
    }
}
