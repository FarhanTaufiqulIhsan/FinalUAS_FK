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
    public partial class PenjuialanProduk : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            cbxIdPj.Enabled = false;
            cbxIdpr.Enabled = false;
            txtIdPjn.Enabled = false;
            dtP.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;

        }
        public PenjuialanProduk()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT ID_Penjualan, Tanggal_Penjualan, ID_Penjual, ID_Produk FROM dbo.Penjualan_Produk";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Penjual p = new Penjual();
            p.Show();
            this.Hide();
        }

        private void txtIdPjn_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbxIdPj.Enabled = true;
            cbxIdpr.Enabled = true;
            txtIdPjn.Enabled = true;
            dtP.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            cbIdPj();
            cbIdpr();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void cbIdPj()
        {
            koneksi.Open();
            string query = "SELECT ID_Penjual, Nama_Penjual FROM Penjual";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Penjual");
            dt.Columns.Add("Nama_Penjual");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Penjual"] = reader["ID_Penjual"].ToString();
                row["Nama_Penjual"] = reader["Nama_Penjual"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdPj.DisplayMember = "Nama_Penjual";
            cbxIdPj.ValueMember = "ID_Penjual";
            cbxIdPj.DataSource = dt;
        }

        private void cbIdpr()
        {
            koneksi.Open();
            string query = "SELECT ID_Produk, Nama_Produk FROM Produk";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Produk");
            dt.Columns.Add("Nama_Produk");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Produk"] = reader["ID_Produk"].ToString();
                row["Nama_Produk"] = reader["Nama_Produk"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdpr.DisplayMember = "Nama_Produk";
            cbxIdpr.ValueMember = "ID_Produk";
            cbxIdpr.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idpenjual = cbxIdPj.SelectedValue.ToString();
            string idproduk = cbxIdpr.SelectedValue.ToString();
            string idpenjualan = txtIdPjn.Text;
            string date = dtP.Text;

            if (idpenjual == "")
            {
                MessageBox.Show("Pilih Nama Penjual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idproduk == "")
            {
                MessageBox.Show("Pilih Nama produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (date == "")
            {
                MessageBox.Show("Masukkan Tanggal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idpenjualan == "")
            {
                MessageBox.Show("Masukkan ID Penjualan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO Penjualan_Produk (ID_Penjualan, Tanggal_Penjualan, ID_Penjual, ID_Produk) VALUES (@ID_Penjualan, @Tanggal_Penjualan, @ID_Penjual, @ID_Produk)";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Penjual", idpenjual);
                command.Parameters.AddWithValue("@ID_Suplier", idproduk);
                command.Parameters.AddWithValue("@Tanggal_Penjualan", date);
                command.Parameters.AddWithValue("@ID_Penjualan", idpenjualan);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform(); 
                        dataGridView();
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
    }
}
