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
    public partial class TransaksiPP : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtIdt.Text = "";
            txtTb.Text = "";
            cbxIdPl.Enabled = false;
            cbxIdPr.Enabled = false;
            dtT.Enabled = false;
            txtTb.Enabled = false;
            txtIdt.Enabled = false;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
        }
        public TransaksiPP()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "select * from dbo.Transaksi_PP";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void cbIdPr()
        {
            koneksi.Open();
            string query = "SELECT ID_Produk FROM Produk";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Produk");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Produk"] = reader["ID_Produk"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdPr.DisplayMember = "ID_Produk";
            cbxIdPr.ValueMember = "ID_Produk";
            cbxIdPr.DataSource = dt;
        }

        private void cbIdPl()
        {
            koneksi.Open();
            string query = "SELECT ID_Pelanggan FROM Pelanggan";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Pelanggan");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Pelanggan"] = reader["ID_Pelanggan"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdPl.DisplayMember = "ID_Pelanggan";
            cbxIdPl.ValueMember = "ID_Pelanggan";
            cbxIdPl.DataSource = dt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Pelanggan p = new Pelanggan();
            p.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbxIdPl.Enabled = true;
            cbxIdPr.Enabled = true;
            dtT.Enabled = true;
            txtTb.Enabled = true;
            txtIdt.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            cbIdPl();
            cbIdPr();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idProduk = cbxIdPr.SelectedValue.ToString();
            string idPelanggan = cbxIdPl.SelectedValue.ToString();
            string date = dtT.Text;
            string total = txtTb.Text;
            string idtransaksi = txtIdt.Text;

            if (idProduk == "")
            {
                MessageBox.Show("Pilih ID Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idPelanggan == "")
            {
                MessageBox.Show("Pilih ID Pelanggan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (date == "")
            {
                MessageBox.Show("Masukkan Tanggal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (total == "")
            {
                MessageBox.Show("Masukkan Total Bayar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idtransaksi == "")
            {
                MessageBox.Show("Masukkan ID Transaksi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO Transaksi_PP (ID_Produk, ID_Pelanggan, Tanggal_Transaksi, Total_Bayar, ID_Transaksi) VALUES (@ID_Produk, @ID_Pelanggan, @Tanggal_Transaksi, @Total_Bayar, @ID_Transaksi)";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Produk", idProduk);
                command.Parameters.AddWithValue("@ID_Pelanggan", idPelanggan);
                command.Parameters.AddWithValue("@Tanggal_Transaksi", date);
                command.Parameters.AddWithValue("@Total_Bayar", total);
                command.Parameters.AddWithValue("@ID_Transaksi", idtransaksi);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform(); // Mengosongkan form setelah menyimpan
                        dataGridView(); // Refresh tampilan data setelah menyimpan
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
