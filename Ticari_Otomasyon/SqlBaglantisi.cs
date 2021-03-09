//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-2JVKJTR\SQLEXPRESS;Initial Catalog=DBoTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}