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
    public partial class Form_FaturaUrunDuzenleme : Form
    {
        public Form_FaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string id;
        private void Form_FaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            TxtUrunId.Text = id;
            SqlCommand komut = new SqlCommand("select * from TBL_FATURADETAY WHERE FATURAURUNID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", id);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtFiyat.Text = dr[3].ToString();
                TxtAdet.Text = dr[2].ToString();
                TxtTutar.Text = dr[4].ToString();
                TxtUrunAd.Text = dr[1].ToString();
                bgl.baglanti().Close();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY SET URUNAD=@P1, MIKTAR=@P2, FIYAT=@P3, TUTAR=@P4 WHERE FATURAURUNID=@P5", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtAdet.Text);
            komut.Parameters.AddWithValue("@P3",decimal.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@P4",decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@P5", id);
            DialogResult secenek = MessageBox.Show("Değişiklik kaydedilsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAURUNID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", id);
            DialogResult secenek = MessageBox.Show("Silinsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
            }
            bgl.baglanti().Close();
        }
    }
}