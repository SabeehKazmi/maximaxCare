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
     
    public partial class AddPatient : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r, inc = 1, total;
        DialogResult dr = new DialogResult();
        public AddPatient()
        {
            InitializeComponent();
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {
            //combobox fill code from table values
            query = "select P_Type from Patient_Type";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox3.Items.Contains(val))
                {
                    comboBox3.Items.Add(val);
                }
            }
            //same as above but for a different combobox
            query = "select Disease from Test";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
            }
            //same as above but for a different combobox
            query = "select Med_Name from Medicine";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox5.Items.Contains(val))
                {
                    comboBox5.Items.Add(val);
                }
            }

            query = "select * from Patient";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            //increment value set on Sr_No initially value
            // previous defined inc = 0
            txtSr.Text = inc.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //insert fee to textfield according to its patient type automatically
            query = "select Fee from Patient_Type where P_Type = '"+ comboBox3.Text +"'";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox3.Items.Contains(val))
                {
                    txtFee.Text = val;
                }
            }
        }

        private void sfButton5_Click(object sender, EventArgs e)
        {
            //add new patient
            query = "INSERT INTO Patient (P_Type, Fee, Pt_Ref_No, Pt_Name, Age, Gender, Contact_No, Address, Allergies, Temp, BP, Presenting_Comp, History, Med_Subsidy, Findings, Investigations, Date)" +
                    " VALUES ('" + comboBox3.Text + "','" + txtFee.Text + "','" + txtPtRef.Text + "','" + txtPtName.Text + "','" + txtAge.Text + "','" + txtGender.Text + "','" + txtMaskCon.Text + "','" + txtAddress.Text + "','" + rtbAllergies.Text + "','" + txtTempt.Text + "','" + txtBP.Text + "','" + rtbPC.Text + "','" + rtbHis.Text + "','" + txtMed.Text + "','" + rtbFindings.Text + "','" + richTextBox2.Text + "','" + dtpDate.Text + "')";
            try
            {
                rp.savdelup(query);
                dr = (MessageBox.Show("Data Added","Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information));
                query = "select * from Patient";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPtRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaskCon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rtbAllergies_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbPC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMed_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select test according to a specific disease and insert it into tests combobox
            comboBox4.Items.Clear();
            query = "select Tests from Test where Disease = '" + comboBox1.Text + "'";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox3.Items.Contains(val))
                {
                    comboBox4.Items.Add(val);
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selected test will automatically add into investigations textbox
            richTextBox2.Text = richTextBox2.Text + comboBox4.Text + "  /  ";
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //searching of a specific patient
                query = "select * from Patient where Pt_Ref_No = '" + textBox3.Text + "' and Date = '" + dateTimePicker1.Text + "' ";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //updation of a patient
                query = "UPDATE Patient SET P_Type = '" + comboBox3.Text + "', Fee = '" + txtFee.Text + "', Pt_Ref_No = '" + txtPtRef.Text + "', Pt_Name = '" + txtPtName.Text + "', Age = '" + txtAge.Text + "', Gender = '" + txtGender.Text + "', Contact_No = '" + txtMaskCon.Text + "', Address = '" + txtAddress.Text + "', Allergies = '" + rtbAllergies.Text + "', Temp = '" + txtTempt.Text + "', BP = '" + txtBP.Text + "', Presenting_Comp = '" + rtbPC.Text + "', History = '" + rtbHis.Text + "', Med_Subsidy = '" + txtMed.Text + "', Findings = '" + rtbFindings.Text + "', Investigations = '" + richTextBox2.Text + "', Date = '" + dtpDate.Text + "' WHERE Pt_Ref_No = '" + txtPtRef.Text + "'";
                rp.savdelup(query);
                dr = (MessageBox.Show("Updated Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                query = "select * from Patient";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //deletion of a patient
                query = "DELETE FROM Patient WHERE Pt_Ref_No = '" + txtPtRef.Text + "'";
                rp.savdelup(query);
                dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                query = "select * from Patient";
                ds = rp.getdata(query);
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sfButton6_Click(object sender, EventArgs e)
        {
                
                // reset sr_no value
                inc = 1;
                txtSr.Text = inc.ToString();
                total = 0;
        }

        private void txtDrugs_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sfButton6_Click_1(object sender, EventArgs e)
        {
            try
            {
                //delete the previous patient medicine list suggest by the doctor
                //so that the new patient data could available to enter
                query = "DELETE FROM Per_Patient_Med WHERE Pt_Ref_No = '" + txtPtRef.Text + "'";
                rp.savdelup(query);
                dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSr_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (txtPtRef.Text != "")
            {
                //insertion of per patient medicine data into Per_Patient_Med table
                query = "select * from Patient where Pt_Ref_No = '" + txtPtRef.Text + "'";
                ds = rp.getdata(query);
                if (ds.Tables["0"].Rows.Count >= 1)
                {
                    query = "INSERT INTO Per_Patient_Med (Sr_No, Drug, Day, Dose, Date, Pt_Ref_No)" +
                        " VALUES ('" + txtSr.Text + "','" + comboBox5.Text + "','" + txtNo.Text + "','" + comboBox2.Text + "','" + dtpDate.Text + "','" + txtPtRef.Text + "')";
                    try
                    {
                        rp.savdelup(query);
                        query = "select Sr_No, Drug, Day, Dose from Per_Patient_Med";
                        ds = rp.getdata(query);
                        dataGridView2.DataSource = ds.Tables["0"].DefaultView;
                        // increment on sr_no
                        txtSr.Text = total.ToString();
                        inc = inc + 1;
                        txtSr.Text = inc.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    dr = (MessageBox.Show("No Patient Exist.", "Pt_Ref_No is not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Reference Number.","Pt_Ref_No is NULL",MessageBoxButtons.OK,MessageBoxIcon.Error));
            }
        }
    }
}
