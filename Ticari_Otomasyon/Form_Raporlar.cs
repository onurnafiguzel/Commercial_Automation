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
    public partial class Form_Raporlar : Form
    {
        public Form_Raporlar()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Form_Raporlar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DBoTicariOtomasyonDataSet3.TBL_PERSONELLER' table. You can move, or remove it, as needed.
            this.TBL_PERSONELLERTableAdapter.Fill(this.DBoTicariOtomasyonDataSet3.TBL_PERSONELLER);
            // TODO: This line of code loads data into the 'DBoTicariOtomasyonDataSet2.TBL_GIDERLER' table. You can move, or remove it, as needed.
            this.TBL_GIDERLERTableAdapter.Fill(this.DBoTicariOtomasyonDataSet2.TBL_GIDERLER);
            // TODO: This line of code loads data into the 'DBoTicariOtomasyonDataSet1.TBL_MUSTERILER' table. You can move, or remove it, as needed.
            this.TBL_MUSTERILERTableAdapter.Fill(this.DBoTicariOtomasyonDataSet1.TBL_MUSTERILER);
            // TODO: This line of code loads data into the 'DBoTicariOtomasyonDataSet.TBL_FIRMALAR' table. You can move, or remove it, as needed.
            this.TBL_FIRMALARTableAdapter.Fill(this.DBoTicariOtomasyonDataSet.TBL_FIRMALAR);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
        }
    }
}
