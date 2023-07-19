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
    public partial class PenjuialanProduk : Form
    {
        private string stringConnection = "data source=LAPTOP-P9JKEJMQ\\FARHANSQL;" + "database=Pemesanan_Baju_UAS;User ID=sa;password=Laserin45@";
        private SqlConnection koneksi;

        private void refreshform()
        {
            cbxIdPj.Enabled = false;
            cbxIdpr.Enabled = false;
            txtIdPjn.Enabled = false;
            dtP.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;

        }
        public PenjuialanProduk()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Penjual p = new Penjual();
            p.Show();
            this.Hide();
        }

        private void txtIdPjn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
