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
    public partial class Form_Personeller : Form
    {
        public Form_Personeller()
        {
            InitializeComponent();
        }
        
        SqlBaglantisi bgl = new SqlBaglantisi();

        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR FROM TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            TxtGorev.Text = "";
            MskTcNo.Text = "";
            MskTel.Text = "";
            RchAdres.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
        }
        private void Form_Personeller_Load(object sender, EventArgs e)
        {
            PersonelListesi();
            SehirListesi();
            Temizle();
        }       

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTel.Text);
            komut.Parameters.AddWithValue("@P4", MskTcNo.Text);
            komut.Parameters.AddWithValue("@P5", TxtMail.Text);
            komut.Parameters.AddWithValue("@P6", CmbIl.Text);
            komut.Parameters.AddWithValue("@P7", CmbIlce.Text);
            komut.Parameters.AddWithValue("P8", RchAdres.Text);
            komut.Parameters.AddWithValue("@P9", TxtGorev.Text);

            DialogResult secenek = MessageBox.Show("Personel Eklensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                PersonelListesi();
            }
            bgl.baglanti().Close();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("select ILCE FROM TBL_ILCELER WHERE SEHIR=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr!=null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTel.Text = dr["TELEFON"].ToString();
                MskTcNo.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete  from TBL_PERSONELLER WHERE ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtId.Text);

            DialogResult secenek = MessageBox.Show("Personel Silinsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                PersonelListesi();
            }
            bgl.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_PERSONELLER SET AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 WHERE ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTel.Text);
            komut.Parameters.AddWithValue("@P4", MskTcNo.Text);
            komut.Parameters.AddWithValue("@P5", TxtMail.Text);
            komut.Parameters.AddWithValue("@P6", CmbIl.Text);
            komut.Parameters.AddWithValue("@P7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@P8", RchAdres.Text);
            komut.Parameters.AddWithValue("@P9", TxtGorev.Text);
            komut.Parameters.AddWithValue("@P10", TxtId.Text);

            DialogResult secenek = MessageBox.Show("Personel Güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                PersonelListesi();
                Temizle();
            }
            bgl.baglanti().Close();
        }
    }
}