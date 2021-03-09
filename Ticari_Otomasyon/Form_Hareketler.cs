using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Internal;

namespace Ticari_Otomasyon
{
    public partial class Form_Hareketler : Form
    {
        public Form_Hareketler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Firmalistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void MusteriListele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("exec MusteriHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }
       

        private void Form_Hareketler_Load(object sender, EventArgs e)
        {
            Firmalistele();
            MusteriListele();
        }
    }
}
