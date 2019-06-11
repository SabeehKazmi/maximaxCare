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
    public partial class AddTest : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public AddTest()
        {
            InitializeComponent();
        }

        private void AddTest_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                query = "UPDATE Test SET Tests = '" + textBox2.Text + "' WHERE Tests = '" + textBox1.Text + "'";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Updated successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));

                    textBox1.Clear();
                    textBox2.Clear();

                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Test you want to delete.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    //deletion of a test
                    query = "DELETE FROM Test WHERE Tests = '" + textBox2.Text + "'";
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    DialogResult = MessageBox.Show("Enter Valid!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //insertion of a test
                query = "INSERT INTO Test (Disease, Tests) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                try
                {
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    textBox2.Clear();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dr = (MessageBox.Show("Please enter a Test", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
