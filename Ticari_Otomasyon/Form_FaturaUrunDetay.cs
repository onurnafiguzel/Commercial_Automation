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

namespace Ticari_Otomasyon
{
    public partial class Form_FaturaUrunDetay : Form
    {
        public Form_FaturaUrunDetay()
        {
            InitializeComponent();
        }
        public string Id;
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * FROM TBL_FATURADETAY WHERE FATURAID='" + Id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void Form_FaturaUrunDetay_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Form_FaturaUrunDuzenleme fr = new Form_FaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.id = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}