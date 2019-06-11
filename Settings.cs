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
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            //total emplyess data
            query = "select * from author";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            //validations
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    if (comboBox1.Text != "")
                    {
                        if (textBox3.Text != "")
                        {
                            //insert employe
                            query = "INSERT INTO author (User_Name, Password, Date, Role, E_Mail) VALUES ('"+ textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Text + "', '" + comboBox1.Text + "', '" + textBox3.Text + "')";
                            try
                            {
                                rp.savdelup(query);
                                dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                query = "select * from author";
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
                            dr = (MessageBox.Show("Please enter E-Mail", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        }
                    }
                    else
                    {
                        dr = (MessageBox.Show("Please select a role", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error));
                    }
                }
                else
                {
                    dr = (MessageBox.Show("Please enter Password", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            }
            else
            {
                dr = (MessageBox.Show("Please enter User_Name", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    //delete employee on the basis of email
                    query = "DELETE FROM author WHERE E_Mail = '" + textBox3.Text + "'";
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    query = "select * from author";
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
                dr = (MessageBox.Show("The user will delete only on his/her E-Mail address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information));
                textBox3.Focus();
            }
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    //update employee
                    query = "UPDATE author SET User_Name = '" + textBox1.Text + "', Password = '" + textBox2.Text + "', Date = '" + dateTimePicker1.Text + "', Role = '" + comboBox1.Text + "', E_Mail = '" + textBox3.Text + "' WHERE E_Mail = '" + textBox3.Text + "'";
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Updated Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear(); query = "select * from author";
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
                dr = (MessageBox.Show("The user will delete only on his/her E-Mail address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information));
                textBox3.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //searching a specific employee on the basis of username
            query = "select * from author where User_Name Like '" + textBox4.Text + "%'";
            ds = rp.getdata(query);
            r = ds.Tables["0"].Rows.Count;
            if (r > 0)
            {
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            else
            {
                //searching a specific employee on the basis of password
                query = "select * from author where Password Like '" + textBox4.Text + "%'";
                ds = rp.getdata(query);
                r = ds.Tables["0"].Rows.Count;
                if (r > 0)
                {
                    dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                }
                else
                {
                    //searching a specific employee on the basis of email
                    query = "select * from author where E_Mail Like '" + textBox4.Text + "%'";
                    ds = rp.getdata(query);
                    r = ds.Tables["0"].Rows.Count;
                    if (r > 0)
                    {
                        dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                    }
                    else
                    {
                        //searching a specific employee on the basis of role
                        query = "select * from author where Role Like '" + textBox4.Text + "%'";
                        ds = rp.getdata(query);
                        r = ds.Tables["0"].Rows.Count;
                        if (r > 0)
                        {
                            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                        }
                        else
                        {
                            //searching a specific employee on the basis of date
                            query = "select * from author where Date Like '" + textBox4.Text + "%'";
                            ds = rp.getdata(query);
                            r = ds.Tables["0"].Rows.Count;
                            if (r > 0)
                            {
                                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                            }
                            else
                            {
                                MessageBox.Show("Nothing exist.", "No Record Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void sfButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Panel p = new Panel();
            p.Show();
        }
    }
}
