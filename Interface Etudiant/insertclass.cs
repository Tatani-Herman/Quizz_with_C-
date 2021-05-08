using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Interface_Etudiant
{
    class insertclass
    {
        private string cs=@"Data Source=DESKTOP-6SOT833\SQLEXPRESS;Initial Catalog=ensat;Integrated Security=True";
       
        public string insert_srecord(notes n)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(cs);

            try
            {
                SqlCommand cmd = new SqlCommand("[add_notes]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codeElev", SqlDbType.NVarChar,15).Value = n.codeElev;
                cmd.Parameters.Add("@codeMat", SqlDbType.NVarChar,20).Value = n.codeMat;
                cmd.Parameters.Add("@note", SqlDbType.Float).Value = n.note;
                


                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Votre note a bien été enregistrée";




            }
            catch (Exception)
            {


                msg = "Un problème est survenue lors de l'insertion de la note";

            }


            finally
            {
                conn.Close();
            }



            return msg;




        } //method end......................
    }
}
