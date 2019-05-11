using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximaxCare
{
    public partial class Patient : MetroFramework.Forms.MetroForm
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPatient ap = new AddPatient();
            ap.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddTest at = new AddTest();
            at.Show();
        }

        private void sfButton8_Click(object sender, EventArgs e)
        {
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            AddPatient ap = new AddPatient();
            ap.Show();
        }

        private void sfButton5_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }

        private void sfButton6_Click(object sender, EventArgs e)
        {
            PatientType pt = new PatientType();
            pt.Show();
        }

        private void sfButton7_Click(object sender, EventArgs e)
        {
            AddTest at = new AddTest();
            at.Show();
        }
    }
}
