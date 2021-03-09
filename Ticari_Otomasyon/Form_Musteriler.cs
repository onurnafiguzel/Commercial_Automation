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
    public partial class Form_Musteriler : Form
    {
        public Form_Musteriler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void MusteriListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_MUSTERILER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("select SEHIR from TBL_ILLER", bgl.baglanti());
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
            MskTel1.Text = "";
            MskTel2.Text = "";
            MskTcNo.Text = "";
            TxtMail.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            TxtVergi.Text = "";
            RchAdres.Text = "";
        }

        private void Form_Musteriler_Load(object sender, EventArgs e)
        {
            MusteriListesi();
            SehirListesi();
            Temizle();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE FROM TBL_ILCELER WHERE SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTel1.Text);
            komut.Parameters.AddWithValue("@P4", MskTel2.Text);
            komut.Parameters.AddWithValue("@P5", MskTcNo.Text);
            komut.Parameters.AddWithValue("@P6", TxtMail.Text);
            komut.Parameters.AddWithValue("@P7", CmbIl.Text);
            komut.Parameters.AddWithValue("@P8", CmbIlce.Text);
            komut.Parameters.AddWithValue("@P9", RchAdres.Text);
            komut.Parameters.AddWithValue("@P10", TxtVergi.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MusteriListesi();
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_MUSTERILER WHERE ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtId.Text);
            DialogResult secenek = MessageBox.Show("Müşteriyi Sistemden Silmek istiyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MusteriListesi();
            }           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTel1.Text = dr["TELEFON"].ToString();
                MskTel2.Text = dr["TELEFON2"].ToString();
                MskTcNo.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER SET AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,ADRES=@P9,VERGIDAIRE=@P10 WHERE ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTel1.Text);
            komut.Parameters.AddWithValue("@P4", MskTel2.Text);
            komut.Parameters.AddWithValue("@P5", MskTcNo.Text);
            komut.Parameters.AddWithValue("@P6", TxtMail.Text);
            komut.Parameters.AddWithValue("@P7", CmbIl.Text);
            komut.Parameters.AddWithValue("@P8", CmbIlce.Text);
            komut.Parameters.AddWithValue("@P9", RchAdres.Text);
            komut.Parameters.AddWithValue("@P10", TxtVergi.Text);
            komut.Parameters.AddWithValue("@P11", TxtId.Text);

           
            DialogResult secenek=MessageBox.Show("Müşteri Güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MusteriListesi();
            }
            bgl.baglanti().Close();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}