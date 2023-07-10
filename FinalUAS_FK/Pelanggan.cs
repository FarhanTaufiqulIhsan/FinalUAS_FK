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


    }
}
