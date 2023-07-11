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
            string query = "SELECT ID_Penjual FROM Penjual";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Penjual");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Penjual"] = reader["ID_Penjual"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdp.DisplayMember = "ID_Penjual";
            cbxIdp.ValueMember = "ID_Penjual";
            cbxIdp.DataSource = dt;
        }

        private void cbIdS()
        {
            koneksi.Open();
            string query = "SELECT ID_Suplier FROM Suplier";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Suplier");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Suplier"] = reader["ID_Suplier"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdS.DisplayMember = "ID_Suplier";
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
    }
}
