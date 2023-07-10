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
        }

        private void Penjual_Load(object sender, EventArgs e)
        {

        }
    }
}
