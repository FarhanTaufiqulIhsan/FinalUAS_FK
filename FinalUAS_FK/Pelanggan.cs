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
    }
}
