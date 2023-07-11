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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Suplier sp = new Suplier();
            sp.Show();
            this.Hide();
        }
    }
}
