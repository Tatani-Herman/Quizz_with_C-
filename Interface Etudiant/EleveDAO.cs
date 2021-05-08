using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Interface_Etudiant
{
    class EleveDAO
    {
        string sql;
        public EleveDAO()
        {
            Connexion1.Connect_To_Sql_Server();
        }
        public int delete(Eleve E)
        {
            sql = "delete from eleves where codeElev=" +
                "'" + E.CodeElev + "'";
            return Connexion1.IUD(sql);

        }

        public int insert(Eleve E)
        {
            sql = "insert into eleves values" +
                "('" + E.CodeElev + "','" + E.Nom + "','" + E.Prenom + "','" + E.Niveau + "','" + E.Code_fil + "')";
            return Connexion1.IUD(sql);
        }

        public List<Eleve> Select(Eleve E = null)
        {
            SqlDataReader dr;
            sql = "select * from eleves ";
            List<Eleve> list = new List<Eleve>();
            if (E != null)
                sql += " where codeElev='" + E.CodeElev + "' and nom='"+ E.Nom +"'";
            dr = (SqlDataReader)Connexion1.Select(sql);
            while (dr.Read())
                list.Add(new Eleve(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3), dr.GetString(4)));
            dr.Close();
            return list;

        }

        public int update(Eleve E)
        {
            sql = "update eleves set nom='" + E.Nom + "',prenom='" + E.Prenom + "'" + ",niveau=" + E.Niveau + ",code_Fil='" + E.Code_fil + "' ";
            sql += "where codeElev='" + E.CodeElev + "'";
            return Connexion1.IUD(sql);
        }
    }
}
