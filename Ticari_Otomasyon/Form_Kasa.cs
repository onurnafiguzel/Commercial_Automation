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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class Form_Kasa : Form
    {
        public Form_Kasa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void MusteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void FirmaHareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("exec FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        private void Form_Kasa_Load(object sender, EventArgs e)
        {
            MusteriHareket();
            FirmaHareket();

            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("select sum(TUTAR) FROM TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamTutar.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Son Ayın Faturası
            SqlCommand komut2 = new SqlCommand("select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Son Ayın Personel Maaşları
            SqlCommand komut3 = new SqlCommand("select MAASLAR FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPerMaas.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Toplam Müşteri Sayısı
            SqlCommand komut4 = new SqlCommand("select count(*) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusSayi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("select count(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Firma Şehir Sayısı
            SqlCommand komut6 = new SqlCommand("select count(Distinct(IL)) FROM TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblFirmaSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Müşteri Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("SELECT COUNT(DISTINCT(IL)) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblMusSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Personel Sayısı Hesaplama
            SqlCommand komut8 = new SqlCommand("select count(*) FROM TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblPerSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Ürün Sayısı
            SqlCommand komut9 = new SqlCommand("SELECT SUM(ADET) FROM TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
         
            //Elektrik
            if (sayac > 0 && sayac <= 5)
            {
                groupControl10.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }

            //Su
            if (sayac > 5 && sayac <= 10)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Su";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut11 = new SqlCommand("select top 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Doğalgaz";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut12 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }

            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "İnternet";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut13 = new SqlCommand("select top 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglanti().Close();
            }

            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Ekstra";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut14 = new SqlCommand("select top 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac==26)
            {
                sayac = 0;
            }
        }

        int sayac2=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;

            //Elektrik
            if (sayac2 > 0 && sayac2 <= 5)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }

            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Su";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut11 = new SqlCommand("select top 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //Doğalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Doğalgaz";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut12 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }

            //İnternet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "İnternet";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut13 = new SqlCommand("select top 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglanti().Close();
            }

            //Ekstra
            if (sayac2 > 20 && sayac2 <= 25)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Ekstra";
                //2.Char Control'e Su Faturası Son 4 Ay Getirme
                SqlCommand komut14 = new SqlCommand("select top 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }

        }
    }
}