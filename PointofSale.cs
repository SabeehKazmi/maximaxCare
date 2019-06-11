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
    public partial class PointofSale : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query, pt_ref_no;
        int r, inc = 1;
        int total = 0, solo, grandT;
        DialogResult dr = new DialogResult();
        public PointofSale()
        {
            InitializeComponent();
        }

        private void PointofSale_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void sfButton8_Click(object sender, EventArgs e)
        {
            if (txtPtRef.Text != "")
            {
                //will select a specific patient medicine list 
                //so that it could be minused from stock 
                query = "select * from Per_Patient_Med where Pt_Ref_No = '" + txtPtRef.Text + "' and Date == '" + dateTimePicker1.Text + "'";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                pt_ref_no = txtPtRef.Text;
            }
            else
            {
                dr = (MessageBox.Show("Enter the reference number of patient.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        private void txtPtRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDrugs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            dr = (MessageBox.Show("Are you sure?","Saving Data",MessageBoxButtons.YesNo,MessageBoxIcon.Warning));
            if ( dr == DialogResult.Yes)
            {
                // reset sr_no value
                inc = 1;
                txtSr.Text = inc.ToString();
                total = 0;
                // delete the previous data and shows the latest
                query = "DELETE FROM Temp_POS ";
                rp.savdelup(query);
                query = "select * from Temp_POS";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //subsity calculation to total payment
            int sub, op, t;
            sub = Convert.ToInt32(textBox5.Text);
            op = total / 100;
            t = op * sub;
            grandT = total - t;
            textBox4.Text = grandT.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // adding medicine to 2nd gridview
        private void sfButton1_Click(object sender, EventArgs e)
        {
            
            query = "INSERT INTO Temp_POS (Sr_No, Drug, Day, Dose, Date, Pt_Ref_No, Price)" +
                    " VALUES ('" + txtSr.Text + "','" + txtDrugs.Text + "','" + txtNo.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + pt_ref_no + "','" + textBox1.Text + "')";
            try
            {
                rp.savdelup(query);
                textBox1.Clear();
                query = "select * from Temp_POS";
                ds = rp.getdata(query);
                dataGridView2.DataSource = ds.Tables["0"].DefaultView;
                // helps you to total
                query = "select Price from Temp_POS";
                ds = rp.getdata(query);
                 
               for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
                {
                    
                    solo = Convert.ToInt32(ds.Tables["0"].Rows[i][0]);
                    
                    // for checking purposes----   dr = (MessageBox.Show(total.ToString(), solo.ToString(),MessageBoxButtons.OK,MessageBoxIcon.Error));
                }
                total = total + solo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // increment on sr_no

            textBox2.Text = total.ToString();
            inc = inc + 1;
            txtSr.Text = inc.ToString();
        }
    }
}
