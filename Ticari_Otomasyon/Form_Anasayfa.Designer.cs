﻿namespace Ticari_Otomasyon
{
    partial class Form_Anasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Anasayfa));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlStoklar = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.GridControlHareketler = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlAjanda = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlFihrist = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStoklar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHareketler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAjanda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFihrist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControlStoklar);
            this.groupControl1.Location = new System.Drawing.Point(3, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(767, 423);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "AZALAN STOKLAR";
            // 
            // gridControlStoklar
            // 
            this.gridControlStoklar.Location = new System.Drawing.Point(0, 26);
            this.gridControlStoklar.MainView = this.gridView1;
            this.gridControlStoklar.Name = "gridControlStoklar";
            this.gridControlStoklar.Size = new System.Drawing.Size(762, 390);
            this.gridControlStoklar.TabIndex = 6;
            this.gridControlStoklar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.LightSeaGreen;
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControlStoklar;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.GridControlHareketler);
            this.groupControl2.Location = new System.Drawing.Point(3, 430);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(767, 423);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "SON 10 HAREKET";
            // 
            // GridControlHareketler
            // 
            this.GridControlHareketler.Location = new System.Drawing.Point(0, 26);
            this.GridControlHareketler.MainView = this.gridView2;
            this.GridControlHareketler.Name = "GridControlHareketler";
            this.GridControlHareketler.Size = new System.Drawing.Size(762, 390);
            this.GridControlHareketler.TabIndex = 6;
            this.GridControlHareketler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.LightSeaGreen;
            this.gridView2.Appearance.Row.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.GridControl = this.GridControlHareketler;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControlAjanda);
            this.groupControl3.Location = new System.Drawing.Point(776, 1);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(675, 423);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "AJANDA";
            // 
            // gridControlAjanda
            // 
            this.gridControlAjanda.Location = new System.Drawing.Point(0, 26);
            this.gridControlAjanda.MainView = this.gridView3;
            this.gridControlAjanda.Name = "gridControlAjanda";
            this.gridControlAjanda.Size = new System.Drawing.Size(670, 390);
            this.gridControlAjanda.TabIndex = 6;
            this.gridControlAjanda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.LightSeaGreen;
            this.gridView3.Appearance.Row.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.GridControl = this.gridControlAjanda;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.gridControlFihrist);
            this.groupControl4.Location = new System.Drawing.Point(776, 430);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(675, 423);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "FİHRİST";
            // 
            // gridControlFihrist
            // 
            this.gridControlFihrist.Location = new System.Drawing.Point(0, 26);
            this.gridControlFihrist.MainView = this.gridView4;
            this.gridControlFihrist.Name = "gridControlFihrist";
            this.gridControlFihrist.Size = new System.Drawing.Size(670, 390);
            this.gridControlFihrist.TabIndex = 6;
            this.gridControlFihrist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.LightSeaGreen;
            this.gridView4.Appearance.Row.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.GridControl = this.gridControlFihrist;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(1457, 1);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(466, 845);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.webBrowser1);
            this.xtraTabPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.ImageOptions.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(464, 817);
            this.xtraTabPage1.Text = "DÖVİZ KURLARI";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.listBox1);
            this.xtraTabPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.ImageOptions.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(464, 817);
            this.xtraTabPage2.Text = "HABER BAŞLIKLARI";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(464, 817);
            this.webBrowser1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(458, 771);
            this.listBox1.TabIndex = 0;
            // 
            // Form_Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "Form_Anasayfa";
            this.Text = "Form_Anasayfa";
            this.Load += new System.EventHandler(this.Form_Anasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStoklar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHareketler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAjanda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFihrist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlStoklar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl GridControlHareketler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControlAjanda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gridControlFihrist;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox listBox1;
    }
}