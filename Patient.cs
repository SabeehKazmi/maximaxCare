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
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            //shows all the patients 
            query = "select * from Patient";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            dateTimePicker1.Enabled = false;
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

        private void sfButton2_Click(object sender, EventArgs e)
        {
            //sedlect all the patients
            query = "select * from Patient";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //will select the patient where pt_ref_no is similar to the text user will be entering into the textbox
            query = "select * from Patient where Pt_Ref_No Like '" + textBox1.Text + "%'";
            ds = rp.getdata(query);
            r = ds.Tables["0"].Rows.Count;
            if (r > 0)
            {
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            //empty the gridview
            dataGridView1.DataSource = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sfButton4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sfButton8_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Panel p = new Panel();
            p.Show();
        }
    }
}
