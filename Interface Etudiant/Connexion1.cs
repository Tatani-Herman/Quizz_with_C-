using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Interface_Etudiant
{
    class Connexion1
    {
        static IDbConnection cnx = null;
        static IDbCommand cmd = null;

        public static void Connect_To_Sql_Server()
        {
            cnx = new SqlConnection(@"Data Source=DESKTOP-6SOT833\SQLEXPRESS;Initial Catalog=ensat;Integrated Security=True");
            cnx.Open();
            cmd = new SqlCommand();
        }

        public static int IUD(string sql)
        {
            cmd.Connection = cnx;
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery();
        }

        public static IDataReader Select(string sql)
        {
            cmd.Connection = cnx;
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }
    }
}
