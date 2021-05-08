using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ensat_quizz
{
    class Matiere
    {

        String codeMat;
        String designation;
        int niveau;
        String semestre;
        String code_fil;

        public Matiere(String codem, String d=null, int n=0, String s=null, String codef=null)
        {
            codeMat = codem;
            designation = d;
            niveau = n;
            semestre = s;
            code_fil = codef;
        }

        public String CodeMat
        {
            set { codeMat = value; }
            get { return codeMat; }
        }

        public String Designation
        {
            set { designation = value; }
            get { return designation; }
        }

        public int Niveau
        {
            set { niveau = value; }
            get { return niveau; }
        }

        public String Semestre
        {
            set { Semestre = value; }
            get { return semestre; }
        }

        public String Code_fil
        {
            set { code_fil = value; }
            get { return code_fil; }
        }
    }
}
