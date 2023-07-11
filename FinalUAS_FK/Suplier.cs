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
    public partial class Suplier : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;
        
        private void refreshform()
        {
            txtids.Text = "";
            txtnamas.Text = "";
            txtnotelp.Text = "";
            txtalmt.Text = "";
            txtemail.Text = "";
            txtids.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtalmt.Enabled = false;
            txtemail.Enabled = false;
            txtnamas.Enabled = false;
            txtnotelp.Enabled = false;

        }
        public Suplier()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT ID_Suplier, Nama_Suplier, Alamat_Suplier, Nomor_Telepon, Email FROM dbo.Suplier";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void Suplier_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtids.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            txtalmt.Enabled = true;
            txtemail.Enabled = true;
            txtnamas.Enabled = true;
            txtnotelp.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idsuplier = txtids.Text;
            string nmsuplier = txtnamas.Text;
            string almtsuplier = txtalmt.Text;
            string notelp = txtnotelp.Text;
            string email = txtemail.Text;

            if (idsuplier == "")
            {
                MessageBox.Show("Masukkan Id Suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmsuplier == "")
            {
                MessageBox.Show("Masukkan Nama Suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (almtsuplier == "")
            {
                MessageBox.Show("Masukkan Alamat Suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string str = "INSERT INTO Suplier (ID_Suplier, Nama_Suplier, Alamat_Suplier, Nomor_Telepon, Email) VALUES (@ID_Suplier, @Nama_Suplier, @Alamat_Suplier, @Nomor_Telepon, @Email)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ID_Suplier", idsuplier));
                cmd.Parameters.Add(new SqlParameter("@Nama_Suplier", nmsuplier));
                cmd.Parameters.Add(new SqlParameter("@Alamat_Suplier", almtsuplier));
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
