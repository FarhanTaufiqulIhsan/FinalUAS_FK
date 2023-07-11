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
    public partial class TransaksiPP : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtIdt.Text = "";
            txtTb.Text = "";
            cbxIdPl.Enabled = false;
            cbxIdPr.Enabled = false;
            dtT.Enabled = false;
            txtTb.Enabled = false;
            txtIdt.Enabled = false;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
        }
        public TransaksiPP()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "select * from dbo.Transaksi_PP";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void cbIdPr()
        {
            koneksi.Open();
            string query = "SELECT ID_Produk FROM Produk";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Produk");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["ID_Produk"] = reader["ID_Produk"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxIdPr.DisplayMember = "ID_Produk";
            cbxIdPr.ValueMember = "ID_Produk";
            cbxIdPr.DataSource = dt;
        }

        

        private void btnBack_Click(object sender, EventArgs e)
        {
            Pelanggan p = new Pelanggan();
            p.Show();
            this.Hide();
        }
    }
}
