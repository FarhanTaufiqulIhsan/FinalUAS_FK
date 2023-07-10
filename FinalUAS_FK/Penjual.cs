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
    }
}
