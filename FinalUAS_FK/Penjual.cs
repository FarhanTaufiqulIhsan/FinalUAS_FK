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
    public partial class Penjual : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtIdp.Text = "";
            txtAlmt.Text = "";
            txtNamaP.Text = "";
            txtNotelp.Text = "";
            txtEmail.Text = "";
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtIdp.Enabled = false;
            txtAlmt.Enabled = false;
            txtNamaP.Enabled = false;
            txtNotelp.Enabled = false;
            txtEmail.Enabled = false;

        }
        public Penjual()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();  
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT ID_Penjual, Nama_Penjual, Alamat_Penjual, Nomor_Telepon, Email FROM dbo.Penjual";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }



        private void Penjual_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtIdp.Enabled = true;
            txtAlmt.Enabled = true;
            txtEmail.Enabled = true;
            txtNamaP.Enabled = true;
            txtNotelp.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idpenjual = txtIdp.Text;
            string nmpenjual = txtNamaP.Text;
            string almtpenjual = txtAlmt.Text;
            string notelp = txtNotelp.Text;
            string email = txtEmail.Text;

            if (idpenjual == "")
            {
                MessageBox.Show("Masukkan Id Penjual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmpenjual == "")
            {
                MessageBox.Show("Masukkan Nama Penjual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (almtpenjual == "")
            {
                MessageBox.Show("Masukkan Alamat Penjual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string str = "INSERT INTO Penjual (ID_Penjual, Nama_Penjual, Alamat_Penjual, Nomor_Telepon, Email) VALUES (@ID_Penjual, @Nama_Penjual, @Alamat_Penjual, @Nomor_Telepon, @Email)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ID_Penjual", idpenjual));
                cmd.Parameters.Add(new SqlParameter("@Nama_Penjual", nmpenjual));
                cmd.Parameters.Add(new SqlParameter("@Alamat_Penjual", almtpenjual));
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

        //Button Penjualan
        private void button1_Click(object sender, EventArgs e)
        {
            PenjuialanProduk pp = new PenjuialanProduk();
            pp.Show();
            this.Hide();
        }
    }
}
