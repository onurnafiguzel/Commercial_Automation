using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class Form_AnaModule : Form
    {
        public Form_AnaModule()
        {
            InitializeComponent();
        }
       
        Form_Urunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr==null)
            {
                fr = new Form_Urunler();
                fr.MdiParent = this;
                fr.Show();
            }           
        }

        Form_Musteriler fr2;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            if (fr2==null)
            {
                fr2 = new Form_Musteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        Form_Firmalar fr3;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3==null)
            {
                fr3 = new Form_Firmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        Form_Personeller fr4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4==null)
            {
                fr4 = new Form_Personeller();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        Form_Rehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5==null)
            {
                fr5 = new Form_Rehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        
        Form_Giderler fr6;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6==null || IsDisposed)
            {
                fr6 = new Form_Giderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        Form_Bankalar fr7;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7==null || IsDisposed)
            {
                fr7 = new Form_Bankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        Form_Faturalar fr8;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {
                fr8 = new Form_Faturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        Form_Notlar fr9;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9==null)
            {
                fr9 = new Form_Notlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }

        Form_Hareketler fr10;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10==null)
            {
                fr10 = new Form_Hareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        Form_Raporlar fr11;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11==null)
            {
                fr11 = new Form_Raporlar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        Form_Stoklar fr12;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12==null || fr12.IsDisposed)
            {
                fr12 = new Form_Stoklar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        Form_Ayarlar fr13;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13==null || fr13.IsDisposed)
            {
                fr13 = new Form_Ayarlar();
                fr13.Show();
            }
        }

        Form_Kasa fr14;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14==null || fr14.IsDisposed)
            {
                fr14 = new Form_Kasa();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        Form_Anasayfa fr15;
        private void BtnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15==null || fr15.IsDisposed)
            {
                fr15 = new Form_Anasayfa();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        private void Form_AnaModule_Load(object sender, EventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Form_Anasayfa();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
    }
}