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
    public partial class Form_Ayarlar : Form
    {
        public Form_Ayarlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADMIN", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            TxtKullaniciAd.Text = "";
            TxtSifre.Text = "";
        }
        private void Form_Ayarlar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            if (BtnIslem.Text=="Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN (KULLANICIAD,SIFRE) VALUES (@P1,@P2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni kullanıcı eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }

            if (BtnIslem.Text=="Güncelle")
            {
                SqlCommand komut2 = new SqlCommand("update TBL_ADMIN SET SIFRE=@P2 WHERE KULLANICIAD=@P1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", TxtKullaniciAd.Text);
                komut2.Parameters.AddWithValue("@P2", TxtSifre.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Şifre değiştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtKullaniciAd.Text = dr["KULLANICIAD"].ToString();
                TxtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void TxtKullaniciAd_TextChanged(object sender, EventArgs e)
        {
            if (TxtKullaniciAd.Text != "")
            {
                BtnIslem.Text = "Güncelle";
                BtnIslem.BackColor = Color.GreenYellow;
            }
            else
            {
                BtnIslem.Text = "Kaydet";
                BtnIslem.BackColor = Color.MediumTurquoise;
            }
        }
    }
}
