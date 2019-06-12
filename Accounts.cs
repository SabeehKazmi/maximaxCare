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
    public partial class Accounts : MetroFramework.Forms.MetroForm
    {
        //basic referances declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public Accounts()
        {
            InitializeComponent();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            //insert the values into combo boxes required
            query = "select Expense_Head from Expense_Type";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                    comboBox2.Items.Add(val);
                }
            }
            //shows the updated table at start
            query = "select * from Expense_Type";
            ds = rp.getdata(query);
            dataGridView3.DataSource = ds.Tables["0"].DefaultView;
        }

        private void sfButton6_Click(object sender, EventArgs e)
        {
          
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void sfButton7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //insertion into expense_type
                query = "INSERT INTO Expense_Type (Expense_Head)" +
                    " VALUES ('" + textBox1.Text + "')";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from Expense_Type";
                    ds = rp.getdata(query);
                    dataGridView3.DataSource = ds.Tables["0"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Expense Head", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void sfButton8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                // deteting a expense_type specific row
                query = "DELETE FROM Expense_Type WHERE Expense_Head = '" + textBox1.Text + "'";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Deleted successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from Expense_Type";
                    ds = rp.getdata(query);
                    dataGridView3.DataSource = ds.Tables["0"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Expense Head", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void sfButton9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            //inserting the expences into expense table and shows the updated table
            if (textBox9.Text != "")
            {
                query = "INSERT INTO Expense (Date, Expense_Head, Expense_Amount)" +
                    " VALUES ('" + dateTimePicker1.Text + "', '" + comboBox1.Text + "', '" + textBox9.Text + "')";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from Expense";
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
                dr = (MessageBox.Show("Enter Expense Amount", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            //shows the expenses between two manually selected dates according to its expense_head
            query = "select * from Expense where Expense_Head = '"+ comboBox2.Text +"' and Date >= '"+ dateTimePicker2.Text +"' and Date <= '"+ dateTimePicker3.Text +"'";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Panel p = new Panel();
            p.Show();//searching into 4 cataguries
            if ( comboBox3.Text == "Total Profit")
            {
                // profit table show
                query = "select * from Profit where Date >= '" + dateTimePicker2.Text + "' and Date <= '" + dateTimePicker3.Text + "'";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
            }
            else
            {
                if (comboBox3.Text == "Total Loss")
                {
                    //loss table show between two specific dates
                    query = "select * from Loss where Date >= '" + dateTimePicker2.Text + "' and Date <= '" + dateTimePicker3.Text + "'";
                    ds = rp.getdata(query);
                    dataGridView2.DataSource = ds.Tables["0"].DefaultView;
                }
                else
                {
                    if (comboBox3.Text == "Profit over Patient")
                    {
                        //profit from patients
                        query = "select * from Profit where Fee != '' and Date >= '" + dateTimePicker2.Text + "' and Date <= '" + dateTimePicker3.Text + "'";
                        ds = rp.getdata(query);
                        dataGridView2.DataSource = ds.Tables["0"].DefaultView;
                    }
                    else
                    {
                        if (comboBox3.Text == "Profit over Medicine")
                        {
                            try
                            {
                                //profit from medicines
                                query = "select * from Profit where Fee = '' and Date >= '" + dateTimePicker2.Text + "' and Date <= '" + dateTimePicker3.Text + "'";
                                ds = rp.getdata(query);
                                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            
                        }
                        else
                        {
                            dr = (MessageBox.Show("Enter someting", "Null Entry", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            //insertion into combobox from table
            query = "select Expense_Head from Expense_Type";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            //combobox insertion from expense_head table
            query = "select Expense_Head from Expense_Type";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox2.Items.Add(val);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sfButton6_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Panel p = new Panel();
            p.Show();
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            DGVPrinter dGV = new DGVPrinter();



            dGV.Title = "MaximaxCare";

            dGV.SubTitle = string.Format("Date:{0}", DateTime.Now.ToString());
            dGV.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            dGV.PageNumbers = true;
            dGV.PageNumberInHeader = false;
            dGV.PorportionalColumns = true;
            dGV.HeaderCellAlignment = StringAlignment.Near;
            dGV.PageSettings.Landscape = true;
            //   dGV.DefaultPageSettings.Landscape = true;
            dGV.Footer = "Total Patients" + " : " + "Total Fee Collection" + " : " + textBox1.Text;

            dGV.FooterSpacing = 15;
            dGV.PrintDataGridView(dataGridView1);



        }
    }
}
