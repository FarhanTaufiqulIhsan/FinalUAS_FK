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

        private void Produksi_Load(object sender, EventArgs e)
        {

        }
    }
}
