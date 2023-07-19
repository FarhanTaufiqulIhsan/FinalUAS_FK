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

        private void dataGridView()
        {
            koneksi.Open();
            string query = "select * from dbo.Jenis_Produk";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void cbIdPr()
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

            cbxIdp.DisplayMember = "Nama_Produk";
            cbxIdp.ValueMember = "ID_Produk";
            cbxIdp.DataSource = dt;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            cbxIdp.Enabled = true;
            txtHp.Enabled = true;
            txtMp.Enabled = true;
            txtNjp.Enabled = true;
            cbIdPr();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idProduk = cbxIdp.SelectedValue.ToString();
            string namajenisproduk = txtNjp.Text;
            string ukuran = txtHp.Text;
            string merekproduk = txtMp.Text;

            if (idProduk == "")
            {
                MessageBox.Show("Pilih ID Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (namajenisproduk == "")
            {
                MessageBox.Show("Masukkan Nama Jenis Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ukuran == "")
            {
                MessageBox.Show("Masukkan Ukuran Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (merekproduk == "")
            {
                MessageBox.Show("Masukkan Stok Produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO Jenis_Produk (ID_Produk, Nama_Jenis_Produk, Ukuran_Produk, Merek_Produk) VALUES (@ID_Produk, @Nama_Jenis_Produk, @Ukuran_Produk, @Merek_Produk)";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Produk", idProduk);
                command.Parameters.AddWithValue("@Nama_Jenis_Produk", namajenisproduk);
                command.Parameters.AddWithValue("@Ukuran_Produk", ukuran);
                command.Parameters.AddWithValue("@Merek_Produk", merekproduk);

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

            string id = dataGridView1.SelectedRows[0].Cells["ID_Produk"].Value.ToString();

            string sql = "DELETE FROM Jenis_Produk WHERE ID_Produk = @ID_Produk";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Produk", id);

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

            string id = dataGridView1.SelectedRows[0].Cells["ID_Produk"].Value.ToString();
            string nmjnsproduk = txtNjp.Text;
            string merkproduk = txtMp.Text;
            string ukuranproduk = txtHp.Text;


            if (id == "")
            {
                MessageBox.Show("Kode Produksi tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nmjnsproduk == "")
            {
                MessageBox.Show("Masukkan nama jenis produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (merkproduk == "")
            {
                MessageBox.Show("Masukkan merek produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ukuranproduk == "")
            {
                MessageBox.Show("Masukkan ukuran produk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE Jenis_Produk SET Nama_Jenis_Produk = @Nama_Jenis_Produk, Merek_Produk = @Merek_Produk, Ukuran_Produk = @Ukuran_Produk WHERE ID_Produk = @ID_Produk";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@ID_Produk", id);
                command.Parameters.AddWithValue("@Nama_Jenis_Produk", nmjnsproduk);
                command.Parameters.AddWithValue("@Merek_Produk", merkproduk);
                command.Parameters.AddWithValue("@Ukuran_Produk", ukuranproduk);

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
