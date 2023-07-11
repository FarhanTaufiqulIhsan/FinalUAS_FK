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
    public partial class Pelanggan : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtIdPel.Text = "";
            txtNamaPel.Text = "";
            txtAlmt.Text = "";
            txtNotelp.Text = "";
            txtEmail.Text = "";
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            txtAlmt.Enabled = false;
            txtNotelp.Enabled = false;
            txtEmail.Enabled = false;
            txtIdPel.Enabled = false;
            txtNamaPel.Enabled = false;
        }
        public Pelanggan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT ID_Pelanggan, Nama_Pelanggan, Alamat_Pelanggan, Nomor_Telepon, Email FROM dbo.Pelanggan";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtIdPel.Enabled = true;
            txtNamaPel.Enabled = true;
            txtAlmt.Enabled = true;
            txtNotelp.Enabled = true;
            txtEmail.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idpelanggan = txtIdPel.Text;
            string nmpelanggan = txtNamaPel.Text;
            string almtpelanggan = txtAlmt.Text;
            string notelp = txtNotelp.Text;
            string email = txtEmail.Text;

            if (idpelanggan == "")
            {
                MessageBox.Show("Masukkan Id Pelanggan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmpelanggan == "")
            {
                MessageBox.Show("Masukkan Nama Pelanggan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (almtpelanggan == "")
            {
                MessageBox.Show("Masukkan Alamat Pelanggan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (notelp == "")
            {
                MessageBox.Show("Masukkan No Telepon", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (email == "")
            {
                MessageBox.Show("Masukkan Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Pelanggan (ID_Pelanggan, Nama_Pelanggan, Alamat_Pelanggan, Nomor_Telepon, Email) VALUES (@ID_Pelanggan, @Nama_Pelanggan, @Alamat_Pelanggan, @Nomor_Telepon, @Email)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ID_Pelanggan", idpelanggan));
                cmd.Parameters.Add(new SqlParameter("@Nama_Pelanggan", nmpelanggan));
                cmd.Parameters.Add(new SqlParameter("@Alamat_Pelanggan", almtpelanggan));
                cmd.Parameters.Add(new SqlParameter("@Nomor_Telepon", notelp));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["ID_Pelanggan"].Value.ToString();
            string nmpelanggan = txtNamaPel.Text;
            string almtpelanggan = txtAlmt.Text;
            string notelp = txtNotelp.Text;
            string email = txtEmail.Text;

            if (id == "")
            {
                MessageBox.Show("ID Pelanggan tidak valid", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nmpelanggan == "")
            {
                MessageBox.Show("Masukkan Nama Pelanggan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (almtpelanggan == "")
            {
                MessageBox.Show("Masukkan Alamat Pelanggan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (notelp == "")
            {
                MessageBox.Show("Masukkan No Telepon", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (email == "")
            {
                MessageBox.Show("Masukkan Email", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE Pelanggan SET Nama_Pelanggan = @Nama_Pelanggan, Alamat_Pelanggan = @Alamat_Pelanggan, Nomor_Telepon = @Nomor_Telepon, Email = @Email WHERE ID_Pelanggan = @ID_Pelanggan";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Pelanggan", id);
                command.Parameters.AddWithValue("@Nama_Pelanggan", nmpelanggan);
                command.Parameters.AddWithValue("@Alamat_Pelanggan", almtpelanggan);
                command.Parameters.AddWithValue("@Nomor_Telepon", notelp);
                command.Parameters.AddWithValue("@Email", email);

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

        private void btnDlt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["ID_Pelanggan"].Value.ToString();

            string sql = "DELETE FROM Pelanggan WHERE ID_Pelanggan = @ID_Pelanggan";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Pelanggan", id);

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

        private void btnTrPP_Click(object sender, EventArgs e)
        {
            TransaksiPP tpp = new TransaksiPP();
            tpp.Show();
            this.Hide();
        }
    }
}
