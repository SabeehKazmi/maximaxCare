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
    public partial class AddCat : MetroFramework.Forms.MetroForm
    {
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public AddCat()
        {
            InitializeComponent();
        }

        private void AddCat_Load(object sender, EventArgs e)
        {
            query = "select * from Catagory";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                query = "INSERT INTO Catagory (Cat) VALUES ('" + textBox1.Text + "')";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from Catagory";
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
                dr = (MessageBox.Show("Please enter a valid catagory", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    query = "DELETE FROM Catagory WHERE Cat = '" + textBox1.Text + "'";
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from catagory";
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
                dr = (MessageBox.Show("Please enter a catagory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information));
                textBox1.Focus();
            }
        }
    }
}
