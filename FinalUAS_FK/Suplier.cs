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
            txtids.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            txtalmt.Enabled = false;
            txtalmt.Enabled = false;
            txtnamas.Enabled = false;
            txtnotelp.Enabled = false;
        }
        public Suplier()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void Suplier_Load(object sender, EventArgs e)
        {

        }
    }
}
