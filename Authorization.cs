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
    public partial class Authorization : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        string date = DateTime.Now.ToString();

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxExt1.Text != string.Empty)
                {
                    //authenticate the provided information by data into table
                    query = "SELECT * FROM Author WHERE User_Name = '"+ textBoxExt1.Text +"' and Password = '"+ textBoxExt2.Text +"' and Role = '"+ comboBox1.SelectedItem.ToString() +"'";
                    ds = rp.getdata(query);
                    r = ds.Tables["0"].Rows.Count;
                    if (r > 0)
                    {
                        this.Hide();
                        Panel p = new Panel();
                        p.Show();
                    }
                    else
                    {
                        dr = (MessageBox.Show("No User Exist", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error));
                        if (dr == DialogResult.Retry)
                        {
                            textBoxExt1.Text = "";
                            textBoxExt2.Text = "";
                            textBoxExt1.Focus();
                        }
                    }
                }
                else
                {
                    dr = (MessageBox.Show("Please provide a User Name that we can process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxExt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxExt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            //forget passowrd code
            dr = (MessageBox.Show("Are you sure?", "Confermation", MessageBoxButtons.YesNo,MessageBoxIcon.Information));
            if (dr == DialogResult.Yes)
            {
                ForgetP fp = new ForgetP();
                fp.Show();
                this.Hide();
            }
        }
    }
}
