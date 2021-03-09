using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class Form_Mail : Form
    {
        public Form_Mail()
        {
            InitializeComponent();
        }

        public string mail;
        private void Form_Mail_Load(object sender, EventArgs e)
        {
            TxtMailAdresi.Text = mail;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("ongguzel@gmail.com", "masa1234");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(TxtMailAdresi.Text);
            mesajim.From = new MailAddress("ongguzel@gmail.com");
            mesajim.Subject = TxtKonu.Text;
            mesajim.Body = RchMesaj.Text;
            istemci.Send(mesajim);
        }
    }
}