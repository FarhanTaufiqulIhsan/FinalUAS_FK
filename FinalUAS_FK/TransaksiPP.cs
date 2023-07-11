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

        private void refresform()
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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Pelanggan p = new Pelanggan();
            p.Show();
            this.Hide();
        }
    }
}
