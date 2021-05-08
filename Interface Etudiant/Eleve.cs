using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Etudiant
{
    class Eleve
    {
        String codeElev;
        String nom;
        String prenom;
        int niveau;
        String code_fil;

        public Eleve(string codeElev, string nom, string prenom=null, int niveau=0, string code_fil=null)
        {
            this.codeElev = codeElev;
            this.nom = nom;
            this.prenom = prenom;
            this.niveau = niveau;
            this.code_fil = code_fil;
        }

        public String CodeElev
        {
            get { return codeElev; }
            set { codeElev = value; }
        }

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public String Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public int Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        public String Code_fil
        {
            get { return code_fil; }
            set { code_fil = value; }
        }

    }
}
