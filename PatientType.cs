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
    public partial class PatientType : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public PatientType()
        {
            InitializeComponent();
        }

        private void PatientType_Load(object sender, EventArgs e)
        {
            //initally selection and insertion into combobox that contain patient type
            query = "select P_Type from Patient_Type";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
            }
            query = "select * from Patient_Type";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sfButton8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //patient type insertion
                query = "INSERT INTO Patient_Type (P_Type, P_Desc)" +
                    " VALUES ('" + textBox1.Text + "', '"+ textBox5.Text +"')";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    textBox5.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Patient Type", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select the description and shows it into combobox
            query = "SELECT P_Desc from Patient_Type where P_Type = '"+ comboBox1.Text +"'";
            ds = rp.getdata(query);
            var val = ds.Tables["0"].Rows[0][0].ToString();
            textBox2.Text = val;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                //save patient type
                query = "UPDATE Patient_Type SET Fee = '" + textBox4.Text + "' WHERE P_Type = '" + comboBox1.Text + "'";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    
                    textBox4.Clear();

                    query = "select * from Patient_Type";
                    ds = rp.getdata(query);
                    dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Patient Type", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                //update patient type
                query = "UPDATE Patient_Type SET Fee = '" + textBox4.Text + "' WHERE P_Type = '" + comboBox1.Text + "'";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Updated successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));

                    textBox4.Clear();

                    query = "select * from Patient_Type";
                    ds = rp.getdata(query);
                    dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Patient Type", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //delete the patient type from patient_type table
                query = "DELETE FROM Patient_Type WHERE P_Type = '" + comboBox1.Text + "'";
                rp.savdelup(query);
                dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                textBox1.Clear();
                query = "select * from Patient_Type";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

            
        }
    }
}
