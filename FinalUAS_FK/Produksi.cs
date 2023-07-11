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
    public partial class Produksi : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtKp.Text = "";
            txtKp.Enabled = false;
            cbxIdP.Enabled = false;
            cbxIdS.Enabled = false;
            dtTp.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        public Produksi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "select * from dbo.Produksi";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void cbIdP()
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

            cbxIdP.DisplayMember = "ID_Produk";
            cbxIdP.ValueMember = "ID_Produk";
            cbxIdP.DataSource = dt;
        }
        private void Produksi_Load(object sender, EventArgs e)
        {

        }
    }
}
