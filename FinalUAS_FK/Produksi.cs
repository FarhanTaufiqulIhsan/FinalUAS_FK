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
using static System.Net.WebRequestMethods;

namespace FinalUAS_FK
{
    public partial class Produksi : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtKp.Text = "";
            txtKp.Enabled = false;
            cbxIdP.Enabled = false;
            cbxIdS.Enabled = false;
            dtTp.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        public Produksi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "select * from dbo.Produksi";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void cbIdP()
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

            cbxIdP.DisplayMember = "Nama_Produk";
            cbxIdP.ValueMember = "ID_Produk";
            cbxIdP.DataSource = dt;
        }

        private void cbIdS()
        {
            koneksi.Open();
            string query = "SELECT ID_Suplier, Nama_Suplier FROM Suplier";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Suplier");
            dt.Columns.Add("Nama_Suplier");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Suplier"] = reader["ID_Suplier"].ToString();
                row["Nama_Suplier"] = reader["Nama_Suplier"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdS.DisplayMember = "Nama_Suplier";
            cbxIdS.ValueMember = "ID_Suplier";
            cbxIdS.DataSource = dt;
        }
        private void Produksi_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Suplier s = new Suplier();
            s.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtKp.Enabled = true;
            cbxIdP.Enabled = true;
            cbxIdS.Enabled = true;
            dtTp.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            cbIdP();
            cbIdS();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idProduk = cbxIdP.SelectedValue.ToString();
            string idSuplier = cbxIdS.SelectedValue.ToString();
            string date = dtTp.Text;
            string kodeproduksi = txtKp.Text;

            if (idProduk == "")
            {
                MessageBox.Show("Pilih ID Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idSuplier == "")
            {
                MessageBox.Show("Pilih ID Suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (date == "")
            {
                MessageBox.Show("Masukkan Tanggal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kodeproduksi == "")
            {
                MessageBox.Show("Masukkan Kode Produksi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            string sql = "INSERT INTO Produksi (ID_Produk, ID_Suplier, Tanggal_Produksi, Kode_Produksi) VALUES (@ID_Produk, @ID_Suplier, @Tanggal_Produksi, @Kode_Produksi)";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Produk", idProduk);
                command.Parameters.AddWithValue("@ID_Suplier", idSuplier);
                command.Parameters.AddWithValue("@Tanggal_Produksi", date);
                command.Parameters.AddWithValue("@Kode_Produksi", kodeproduksi);

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

        private void btnDlt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Kode_Produksi"].Value.ToString();

            string sql = "DELETE FROM Produksi WHERE Kode_Produksi = @Kode_Produksi";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@Kode_Produksi", id);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                        dataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Kode_Produksi"].Value.ToString();
            string idsuplier = cbxIdS.SelectedValue.ToString();
            string idproduk = cbxIdP.SelectedValue.ToString();
            string date = dtTp.Text;


            if (id == "")
            {
                MessageBox.Show("Kode Produksi tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idsuplier == "")
            {
                MessageBox.Show("Pilih nama suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idproduk == "")
            {
                MessageBox.Show("Pilih nama produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (date == "")
            {
                MessageBox.Show("Pilih tanggal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE Produksi SET ID_Suplier = @ID_Suplier, ID_Produk = @ID_Produk, Tanggal_Produksi = @Tanggal_Produksi WHERE Kode_Produksi = @Kode_Produksi";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@Kode_Produksi", id);
                command.Parameters.AddWithValue("@ID_Suplier", idsuplier);
                command.Parameters.AddWithValue("@ID_Produk", idproduk);
                command.Parameters.AddWithValue("@Tanggal_Produksi", date);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                        dataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
