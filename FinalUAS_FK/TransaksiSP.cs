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
    public partial class TransaksiSP : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            cbxIdp.Enabled = false;
            cbxIdS.Enabled = false;
            txtIdT.Enabled = false;
            txtTb.Enabled = false;
            txtTb.Text = "";
            txtIdT.Text = "";
            dtT.Enabled = false;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
        }

        public TransaksiSP()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "select * from dbo.Transaksi_SP";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void cbIdp()
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

            cbxIdp.DisplayMember = "Nama_Penjual";
            cbxIdp.ValueMember = "ID_Penjual";
            cbxIdp.DataSource = dt;

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Suplier sp = new Suplier();
            sp.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbxIdp.Enabled = true;
            cbxIdS.Enabled = true;
            txtIdT.Enabled = true;
            txtTb.Enabled = true;
            dtT.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            cbIdp();
            cbIdS();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idPenjual = cbxIdp.SelectedValue.ToString();
            string idSuplier = cbxIdS.SelectedValue.ToString();
            string date = dtT.Text;
            string total = txtTb.Text;
            string idtransaksi = txtIdT.Text;

            if (idPenjual == "")
            {
                MessageBox.Show("Pilih ID Penjual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string sql = "INSERT INTO Transaksi_SP (ID_Penjual, ID_Suplier, Tanggal_Transaksi, Total_Bayar, ID_Transaksi) VALUES (@ID_Penjual, @ID_Suplier, @Tanggal_Transaksi, @Total_Bayar, @ID_Transaksi)";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Penjual", idPenjual);
                command.Parameters.AddWithValue("@ID_Suplier", idSuplier);
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

        private void btnDlt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["ID_Transaksi"].Value.ToString();

            string sql = "DELETE FROM Transaksi_SP WHERE ID_Transaksi = @ID_Transaksi";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Transaksi", id);

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
    }
}
