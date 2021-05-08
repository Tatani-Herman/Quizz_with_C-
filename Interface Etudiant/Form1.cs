using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interface_Etudiant
{
    public partial class Form1 : Form
    {
        // Variables
        string reponseCorrecte;
        int ancien_score = 0;
        int numQuestion;
        int score=0;
         int totalQuestions;
        int poids;
        string rep_choisie;
        int i, ancien_i;

        public Form1()
        {
            
            InitializeComponent();
            
        }
        
         int n = 0;



        //private void checkAnswerEvent(object sender, EventArgs e) //Verifier si la reponse cochée est correcte
        //{
        //    var senderObject = (RadioButton)sender;  //On identifie le sender

        //    if (senderObject.Checked == true)
        //    {
        //        rep_choisie = senderObject.Text;
        //    }

        //    if (rep_choisie == reponseCorrecte) //On verifie si la reponse est correcte
        //    {
        //        score += poids;
        //        i++;
        //    }
        //}
        returnclasse rc = new returnclasse();

        private void Form1_Load(object sender, EventArgs e)
        {
            ancien_score = score;
            ancien_i = i;
            string req = "select min(id) from questions where ref=" + "'" + QuizzChoice.quizz_id + "'";
            numQuestion = Convert.ToInt32(rc.scalarReturn(req));
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var requete = (from a in (from b in dc.GetTable <questions>() 
                                              where b.@ref == QuizzChoice.quizz_id
                                      select b)
                           where a.id== numQuestion
                select a).FirstOrDefault();
            
          
            lblQuestion.Text = requete.intitule.ToString();
            radioButton1.Text = requete.option1;
            radioButton2.Text = requete.option2;
            radioButton3.Text = requete.option3;
            radioButton4.Text = requete.option4;
            reponseCorrecte = requete.Reponse_correcte;
            poids = (int) requete.poids;
            // lblQuestion.Text = rc.scalarReturn("select intitule from questions where id="+ "'" +numQuestion +"'"+  "and ref=" + "'" + QuizzChoice.quizz_id + "'"); //On recupere la question
            //radioButton1.Text = rc.scalarReturn("select option1 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option1;
            //radioButton2.Text = rc.scalarReturn("select option2 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option2;
            //radioButton3.Text = rc.scalarReturn("select option3 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option3;
            // radioButton4.Text = rc.scalarReturn("select option4 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option4;
            //  reponseCorrecte = rc.scalarReturn("select Reponse_correcte from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//on recupere la reponse correcte
            //poids = Convert.ToInt32(rc.scalarReturn("select poids from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'"));
            //On recupere le nombre de question
            Connexion.connectToSql();
            
            SqlDataReader dr;
            string sql = "Select * from questions where ref="+ "'" + QuizzChoice.quizz_id + "'";
            dr = (SqlDataReader)Connexion.executeCommand(sql);
            while (dr.Read()) //On compte toutes les questions Ca sort de la boucle une fois retourné false ie a la fin
            {
                n++;
            }
            totalQuestions = n;
            dr.Close();
            button6.Enabled = false;
        }

        string s;

        private void button5_Click(object sender, EventArgs e)
        {
            
            
            if (radioButton1.Checked== true)
            {
                rep_choisie = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                rep_choisie = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                rep_choisie = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                rep_choisie = radioButton4.Text;
            }
            else
            {
                MessageBox.Show("Veuillez choisir une réponse");
                rep_choisie = null;

            }
            if (rep_choisie != null)
            {
                if (rep_choisie.Equals(reponseCorrecte))
                {
                    score += poids;
                    i++;
                }

                s = rc.scalarReturn("select min(id) from questions where id>" + numQuestion);
                if (s.Equals(""))//Si on est a la fin du quizz
                {

                    //On peut inserer par la suite la note dans le tableau et le professeur peut voir
                    notes n = new notes();
                    n.codeMat = QuizzChoice.codeMatiere;
                    n.codeElev = Login_form.codeElev;
                    n.note = score;
                    insertclass IS = new insertclass();
                    string msg = IS.insert_srecord(n);
                    MessageBox.Show(msg);
                    MessageBox.Show(
                        "Fin du Quizz!" + Environment.NewLine +
                        "Vous avez un score de " + score + " ." + Environment.NewLine +
                        "Et votre nombre de réponses correctes est de " + i);
                   

                    button5.Enabled = false;
                    this.Hide();

                }
                else
                {

                    button6.Enabled = true;
                    numQuestion = Convert.ToInt32(s);
                    DataClasses1DataContext dc = new DataClasses1DataContext();
                    var requete = (from a in (from b in dc.GetTable<questions>()
                                              where b.@ref == QuizzChoice.quizz_id
                                              select b)
                                   where a.id == numQuestion
                                   select a).FirstOrDefault();

                    if (requete == null)
                    {
                        MessageBox.Show(
                        "Fin du Quizz!" + Environment.NewLine +
                        "Vous avez un score de " + score + " ." + Environment.NewLine +
                        "Et votre nombre de réponses correctes est de " + i);
                        //On peut inserer par la suite la note dans le tableau de notes
                        //On peut inserer par la suite la note dans le tableau et le professeur peut voir
                        notes n = new notes();
                        n.codeMat = QuizzChoice.codeMatiere;
                        n.codeElev = Login_form.codeElev;
                        n.note = score;
                        insertclass IS = new insertclass();
                        string msg = IS.insert_srecord(n);
                        MessageBox.Show(msg);
                        button5.Enabled = false;
                        this.Hide();
                    }
                    else
                    {
                        lblQuestion.Text = requete.intitule.ToString();
                        radioButton1.Text = requete.option1;
                        radioButton2.Text = requete.option2;
                        radioButton3.Text = requete.option3;
                        radioButton4.Text = requete.option4;
                        reponseCorrecte = requete.Reponse_correcte;
                        poids = (int)requete.poids;
                    }

                    //lblQuestion.Text = rc.scalarReturn("select intitule from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'"); //On recupere la question
                    //radioButton1.Text = rc.scalarReturn("select option1 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option1;
                    //radioButton2.Text = rc.scalarReturn("select option2 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option2;
                    //radioButton3.Text = rc.scalarReturn("select option3 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option3;
                    //radioButton4.Text = rc.scalarReturn("select option4 from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//option4;
                    //reponseCorrecte = rc.scalarReturn("select Reponse_correcte from questions where id=" + "'" + numQuestion + "'" + "and ref=" + "'" + QuizzChoice.quizz_id + "'");//on recupere la reponse correcte
                    //poids = Convert.ToInt32(rc.scalarReturn("select poids from questions where id=" + "'" + numQuestion + "'" ));

                }
            }
            radiobtn();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            score = ancien_score;
            i = ancien_i;
            radiobtn();
            s = rc.scalarReturn("select max(id) from questions where id<" + numQuestion);
            numQuestion = Convert.ToInt32(s);
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var requete = (from a in (from b in dc.GetTable<questions>()
                                      where b.@ref == QuizzChoice.quizz_id
                                      select b)
                           where a.id == numQuestion
                           select a).FirstOrDefault();
            lblQuestion.Text = requete.intitule.ToString();
            radioButton1.Text = requete.option1;
            radioButton2.Text = requete.option2;
            radioButton3.Text = requete.option3;
            radioButton4.Text = requete.option4;
            reponseCorrecte = requete.Reponse_correcte;
            poids = (int)requete.poids;


        }
        public void radiobtn()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        
    }
}
