using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Interface_Etudiant
{
    class Connexion
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static void connectToSql()
        {
            string cs = @"Data Source=DESKTOP-6SOT833\SQLEXPRESS;Initial Catalog=ensat;Integrated Security=True";
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public static int executeNQCommand(string commandAExecuter)
        {
            cmd.CommandText = commandAExecuter;
            cmd.ExecuteNonQuery();
            return 0;
        }

        public static SqlDataReader executeCommand(string sql)
        {
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }
    }
}
