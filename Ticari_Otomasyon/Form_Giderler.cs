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
    public partial class Form_Giderler : Form
    {
        public Form_Giderler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void GiderlerListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            CmbAy.Text = "";
            CmbYil.Text = "";
            TxtDogalgaz.Text = "";
            TxtEkstra.Text = "";
            TxtElektrik.Text = "";
            TxtInternet.Text = "";
            TxtMaaslar.Text = "";
            TxtSu.Text = "";
            RchNotlar.Text = "";
        }

        private void Form_Giderler_Load(object sender, EventArgs e)
        {
            GiderlerListesi();
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", CmbAy.Text);
            komut.Parameters.AddWithValue("@P2", CmbYil.Text);
            komut.Parameters.AddWithValue("@P3",decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@P4",decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@P5",decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@P6",decimal.Parse(TxtInternet.Text));
            komut.Parameters.AddWithValue("@P7",decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@P8",decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@P9", RchNotlar.Text);

            DialogResult secenek = MessageBox.Show("Gider eklensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                GiderlerListesi();
                Temizle();
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            TxtId.Text = dr["ID"].ToString();
            CmbAy.Text = dr["AY"].ToString();
            CmbYil.Text = dr["YIL"].ToString();
            TxtElektrik.Text = dr["ELEKTRIK"].ToString();
            TxtSu.Text = dr["SU"].ToString();
            TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
            TxtInternet.Text = dr["INTERNET"].ToString();
            TxtMaaslar.Text = dr["MAASLAR"].ToString();
            TxtEkstra.Text = dr["EKSTRA"].ToString();
            RchNotlar.Text = dr["NOTLAR"].ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_GIDERLER WHERE ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtId.Text);

            DialogResult secenek = MessageBox.Show("Gider silinsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                GiderlerListesi();
                Temizle();
            }
            bgl.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER SET AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 WHERE ID=@P10", bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", CmbAy.Text);
            komut.Parameters.AddWithValue("@P2", CmbYil.Text);
            komut.Parameters.AddWithValue("@P3", Decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@P4", Decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@P5", Decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@P6", Decimal.Parse(TxtInternet.Text));
            komut.Parameters.AddWithValue("@P7", Decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@P8", Decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@P9", RchNotlar.Text);
            komut.Parameters.AddWithValue("@P10", TxtId.Text);

            DialogResult secenek = MessageBox.Show("Gider güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek==DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                GiderlerListesi();
                Temizle();
            }
            bgl.baglanti().Close();
        }
    }
}