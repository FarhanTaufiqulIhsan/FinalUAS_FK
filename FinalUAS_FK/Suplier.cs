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
        private string idp, nama, alamat, notelp, email;
        

        public Suplier()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            
        }

        private void Suplier_Load(object sender, EventArgs e)
        {

        }
    }
}
