using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_Etudiant
{
    public partial class Login_form : Form
    {
        EleveDAO dao;
        public static string codeElev;
        public Login_form()
        {
            InitializeComponent();
            dao = new EleveDAO();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            codeElev = password.Text;

            List<Eleve> list = dao.Select(new Eleve(password.Text, username.Text));
            if (list.Count != 0)
            {

                this.Hide();
                MessageBox.Show("Bienvenue chère(e) élève");
                Form2 pann = new Form2();
                pann.Show();
            }
            else
                if (username.Text == "admin" && password.Text == "admin")
            {
                this.Hide();
                MessageBox.Show("Bienvenue chère(e) administrateur");
                quizz q = new quizz();
                q.Show();
            }
            else
            {
                MessageBox.Show("Veuillez vérifier votre username et votre password");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_form_Load(object sender, EventArgs e)
        {
            Connexion1.Connect_To_Sql_Server();
           
        }
    }
}
