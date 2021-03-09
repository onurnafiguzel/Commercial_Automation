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
//using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class Form_Anasayfa : Form
    {
        public Form_Anasayfa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,SUM(ADET) AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD HAVING SUM(ADET)<=20 ORDER BY SUM(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        void Ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select top 10 TARIH,SAAT,BASLIK FROM TBL_NOTLAR ORDER BY ID DESC", bgl.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        void Hareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            GridControlHareketler.DataSource = dt;
        }

        void Fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 FROM TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

        //void Haberler()
        //{
        //    XmlTextReader
        //}

        private void Form_Anasayfa_Load(object sender, EventArgs e)
        {
            Stoklar();
            Ajanda();
            Hareketler();
            Fihrist();

            webBrowser1.Navigate("https://tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
