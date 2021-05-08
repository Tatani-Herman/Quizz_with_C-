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
    public partial class Consultation : Form
    {
        public Consultation()
        {
            InitializeComponent();
        }

        private void Consultation_Load(object sender, EventArgs e)
        {
            string q = "select * from notes where codeElev="+Login_form.codeElev;
            viewclass VC = new viewclass(q);
            
            dataGridView1.DataSource= VC.showrecord();

        }

    }
}
