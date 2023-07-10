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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtIdPro.Enabled = true;
            txtHarga.Enabled = true;
            txtNamaPro.Enabled = true;
            textStok.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idproduk = txtIdPro.Text;
            string nmproduk = txtNamaPro.Text;
            string hrgproduk = txtHarga.Text;
            string stokproduk = textStok.Text;

            if (idproduk == "")
            {
                MessageBox.Show("Masukkan Id Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmproduk == "")
            {
                MessageBox.Show("Masukkan Nama Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (hrgproduk == "")
            {
                MessageBox.Show("Masukkan Harga Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (stokproduk == "")
            {
                MessageBox.Show("Masukkan Stok Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Produk (ID_Produk, Nama_Produk, Harga_Produk, Stok_produk) VALUES (@ID_Produk, @Nama_Produk, @Harga_Produk, @Stok_produk)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ID_Produk", idproduk));
                cmd.Parameters.Add(new SqlParameter("@Nama_Produk", nmproduk));
                cmd.Parameters.Add(new SqlParameter("@Harga_Produk", hrgproduk));
                cmd.Parameters.Add(new SqlParameter("@Stok_produk", stokproduk));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }
    }
}
