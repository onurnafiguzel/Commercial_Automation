using DevExpress.XtraBars;
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

namespace Ticari_Otomasyon
{
    public partial class Form_Stoklar : Form
    {
        public Form_Stoklar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void Form_Stoklar_Load(object sender, EventArgs e)
        {            
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,SUM(ADET) AS 'Miktar' FROM TBL_URUNLER GROUP BY URUNAD", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Chart'a stok miktarı listeleme
            SqlCommand komut = new SqlCommand("Select URUNAD, SUM(ADET) AS 'Miktar' FROM TBL_URUNLER GROUP BY URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(),int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();

            //Chart'a firma şehir sayısı çekme
            SqlCommand komut2 = new SqlCommand("SELECT IL,COUNT(*) FROM TBL_FIRMALAR GROUP BY IL", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(dr2[0].ToString(), int.Parse(dr2[1].ToString()));
            }
            bgl.baglanti().Close();
        }
    }
}