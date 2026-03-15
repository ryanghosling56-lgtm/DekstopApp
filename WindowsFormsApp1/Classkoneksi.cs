using System;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
   public static class Classkoneksi
    {
        public static string ConnectionString = @"Data Source=TKJSTEWA-1\SQLEXPRESS;Initial Catalog=LKS_2026;Integrated Security=True";
        public static string NamaUser;
        public static string StatusUser;

        public static SqlConnection GetConn()
        {  return new SqlConnection(ConnectionString); }
    }

   
        // Tambahkan ini di dalam Classkoneksi.cs

}
