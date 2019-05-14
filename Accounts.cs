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

        }

        private void sfButton9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            query = "select * from Expense_Type";
            ds = rp.getdata(query);
            dataGridView3.DataSource = ds.Tables["0"].DefaultView;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
