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
    public partial class Form_Faturalar : Form
    {
        public Form_Faturalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void FaturaListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            TxtSeriNo.Text = "";
            TxtSiraNo.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtVergiDaire.Text = "";
            TxtAlici.Text = "";
            TxtTeslimAlan.Text = "";
            TxtTeslimEden.Text="";
        }

        private void Form_Faturalar_Load(object sender, EventArgs e)
        {
            FaturaListele();
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtFaturaId.Text=="")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());

                komut.Parameters.AddWithValue("@P1", TxtSeriNo.Text);
                komut.Parameters.AddWithValue("@P2", TxtSiraNo.Text);
                komut.Parameters.AddWithValue("@P3", MskTarih.Text);
                komut.Parameters.AddWithValue("@P4", MskSaat.Text);
                komut.Parameters.AddWithValue("@P5", TxtVergiDaire.Text);
                komut.Parameters.AddWithValue("@P6", TxtAlici.Text);
                komut.Parameters.AddWithValue("@P7", TxtTeslimEden.Text);
                komut.Parameters.AddWithValue("@P8", TxtTeslimAlan.Text);
                DialogResult secenek = MessageBox.Show("Fatura eklensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek==DialogResult.Yes)
                {
                    komut.ExecuteNonQuery();
                    FaturaListele();
                }               
                bgl.baglanti().Close();              
            }

            if (TxtFaturaId.Text!="")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtAdet.Text);
                tutar = Convert.ToDouble(fiyat * miktar);
                TxtTutar.Text = tutar.ToString();

                SqlCommand komut = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());

                komut.Parameters.AddWithValue("@P1", TxtUrunAd.Text);
                komut.Parameters.AddWithValue("@P2", TxtAdet.Text);
                komut.Parameters.AddWithValue("@P3",TxtFiyat.Text);
                komut.Parameters.AddWithValue("@P4", TxtTutar.Text);
                komut.Parameters.AddWithValue("@P5", TxtFaturaId.Text);
                DialogResult secenek = MessageBox.Show("Fatura eklensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek==DialogResult.Yes)
                {
                    komut.ExecuteNonQuery();
                }              
                bgl.baglanti().Close();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtId.Text = dr["FATURABILGIID"].ToString();
                TxtSeriNo.Text = dr["SERI"].ToString();
                TxtSiraNo.Text = dr["SIRANO"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                TxtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
            }
        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FATURABILGI WHERE FATURABILGIID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtId.Text);

            DialogResult secenek = MessageBox.Show("Fatura silinsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                FaturaListele();
            }
            bgl.baglanti().Close();
        }

        private void BtnTemizle_Click_1(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI SET SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 WHERE FATURABILGIID=@P9", bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", TxtSeriNo.Text);
            komut.Parameters.AddWithValue("@P2", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@P3", MskTarih.Text);
            komut.Parameters.AddWithValue("@P4", MskSaat.Text);
            komut.Parameters.AddWithValue("@P5", TxtVergiDaire.Text);
            komut.Parameters.AddWithValue("@P6", TxtAlici.Text);
            komut.Parameters.AddWithValue("@P7", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@P8", TxtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@P9", TxtId.Text);

            DialogResult secenek = MessageBox.Show("Fatura güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                FaturaListele();
            }
            bgl.baglanti().Close();        
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Form_FaturaUrunDetay fr = new Form_FaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr!=null)
            {
                fr.Id = dr["FATURABILGIID"].ToString();              
            }
            fr.Show();
        }
    }
}