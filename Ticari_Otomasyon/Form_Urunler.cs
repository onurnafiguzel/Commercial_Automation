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
    public partial class Form_Urunler : Form
    {
        public Form_Urunler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_URUNLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYil.Text = "";
            NudAdet.Value = 0;
            TxtAlis.Text = "";
            TxtSatis.Text = "";
            RchDetay.Text = "";
        }

        private void Form_Urunler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["URUNAD"].ToString();
                TxtMarka.Text = dr["MARKA"].ToString();
                TxtModel.Text = dr["MODEL"].ToString();
                MskYil.Text = dr["YIL"].ToString();
                TxtAlis.Text = dr["ALISFIYAT"].ToString();
                TxtSatis.Text = dr["SATISFIYAT"].ToString();
                RchDetay.Text = dr["DETAY"].ToString();
            }           
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Verileri Güncelleme
            SqlCommand komutguncelle = new SqlCommand("update TBL_URUNLER SET URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 WHERE ID=@P9", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@P1", TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@P2", TxtMarka.Text);
            komutguncelle.Parameters.AddWithValue("@P3", TxtModel.Text);
            komutguncelle.Parameters.AddWithValue("@P4", MskYil.Text);
            komutguncelle.Parameters.AddWithValue("@P5", NudAdet.Value);
            komutguncelle.Parameters.AddWithValue("@P6", Decimal.Parse(TxtAlis.Text));
            komutguncelle.Parameters.AddWithValue("@P7", Decimal.Parse(TxtSatis.Text));
            komutguncelle.Parameters.AddWithValue("@P8", RchDetay.Text);
            komutguncelle.Parameters.AddWithValue("@P9", TxtId.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komutsil = new SqlCommand("delete from TBL_URUNLER WHERE ID=@P1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@P1", TxtId.Text);
            DialogResult secenek = MessageBox.Show("Ürün Sistemden Silinsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Verileri Kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@P3", TxtModel.Text);
            komut.Parameters.AddWithValue("@P4", MskYil.Text);
            komut.Parameters.AddWithValue("@P5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@P8", RchDetay.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}