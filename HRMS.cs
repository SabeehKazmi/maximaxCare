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
    public partial class HRMS : MetroFramework.Forms.MetroForm
    {
        //basic declaration helps to connect to database and used for performing some incode basics
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query, status;
        DialogResult dr = new DialogResult();
        public HRMS()
        {
            InitializeComponent();
        }

        private void HRMS_Load(object sender, EventArgs e)
        {
            //show all employess in a gridview
            query = "select * from Employee";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLN_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void maskCNIC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDep_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdsalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDOJ_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            //insertion of an employee
            query = "INSERT INTO Employee (F_Name, L_Name, DOB, CNIC, Contact_No, Address, Position, Salary, DOJ, Status, D_O_L_P)" +
                    " VALUES ('" + txtFName.Text + "','" + txtLN.Text + "','" + dtpDOB.Text + "','" + maskCNIC.Text + "','" + txtContact.Text + "','" + txtAddress.Text + "','" + txtDep.Text + "','" + txtAdsalary.Text + "','" + dtpDOJ.Text + "','PAID','" + dtpDOJ.Text + "')";
            try
            {
                rp.savdelup(query);
                query = "select * from Employee";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //updation of an employee
                query = "UPDATE Employee SET F_Name = '" + txtFName.Text + "', L_Name = '" + txtLN.Text + "', DOB = '" + dtpDOB.Text + "', CNIC = '" + maskCNIC.Text + "', Contact_No = '" + txtContact.Text + "', Address = '" + txtAddress.Text + "', Position = '" + txtDep.Text + "', Salary = '" + txtAdsalary.Text + "', DOJ = '" + dtpDOJ.Text + "' WHERE Contact_No = '" + txtContact.Text + "'";
                rp.savdelup(query);
                dr = (MessageBox.Show("Updated Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                query = "select * from Employee";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //deletion of an employee
                query = "DELETE FROM Employee WHERE Contact_No = '" + txtContact.Text + "'";
                rp.savdelup(query);
                dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                query = "select * from Employee";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //salary status update auto
           /*  work in progress
            query = "select D_O_L_P from Employee";
            ds = rp.getdata(query);

            var d = DateTime.Now;
            d = d.AddMonths(-1);

            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var c = Convert.ToString(ds.Tables["0"].Rows[i][0]);
                if (c = d)
                {

                }
            }
            */
            if (comboBox1.SelectedItem.ToString() == "Paid")
            {
                //if the user wants to findout all the employess that salary is paid
                query = "select * from Employee where Status = 'Paid'";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
            }
            else if (comboBox1.SelectedItem.ToString() == "Unpaid")
            {
                //if the user wants to findout all the employess that salary is not paid
                query = "select * from Employee where Status = 'Unpaid'";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
            }
            else
            {
                //shows all the emplyess 
                query = "select * from Employee";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton5_Click(object sender, EventArgs e)
        {
            //search a specific employess on the basis of his/her contact number
            query = "select * from Employee where Contact_No = '"+ textBox1.Text +"'";
            ds = rp.getdata(query);
            dataGridView2.DataSource = ds.Tables["0"].DefaultView;
            //automatically pick the user name and shows it into a textbox
            query = "select F_Name from Employee where Contact_No = '" + textBox1.Text + "'";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                textBox7.Text = Convert.ToString(ds.Tables["0"].Rows[i][0]);
            }
            //pick the specific employee salary
            query = "select Salary from Employee where Contact_No = '" + textBox1.Text + "'";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                textBox8.Text = Convert.ToString(ds.Tables["0"].Rows[i][0]);
            }
            //pick the status of a specific searched employee
            query = "select Status from Employee where Contact_No = '" + textBox1.Text + "'";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                if (Convert.ToString(ds.Tables["0"].Rows[i][0]) == "PAID")
                {
                    checkBoxAdv1.Checked = true;
                }
                else
                {
                    checkBoxAdv1.Checked = false;
                    status = textBox1.Text;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAdv1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sfButton6_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel p = new Panel();
            p.Show();
        }

        private void sfButton7_Click(object sender, EventArgs e)
        {
            //it status the employee as paid
            if (checkBoxAdv1.Checked == true)
            {
                dr = (MessageBox.Show("Already Paid.", "Select the Valid", MessageBoxButtons.OK,MessageBoxIcon.Information));
            }
            else
            {
                query = "UPDATE Employee SET Status = 'PAID', D_O_L_P = '"+ dateTimePicker3.Text +"' where Contact_No = '"+ status +"' ";
                rp.savdelup(query);
                dr = (MessageBox.Show("Updated Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                query = "select * from Employee";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
                //add to expense
                query = "INSERT INTO Expense (Date, Expense_Head, Expense_Amount) " +
                                                       "VALUES ('" + dateTimePicker3.Text +"', 'Salary', '" + textBox8.Text + "')";
            }
        }
    }
}
