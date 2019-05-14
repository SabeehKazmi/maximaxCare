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
    public partial class AddMed : MetroFramework.Forms.MetroForm
    {
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        float PiP, QPP, qty, pPrice, sPrice, ReorderP, ppp, spp, stock;
        int reorderQ;
        public AddMed()
        {
            InitializeComponent();
        }

        private void AddMed_Load(object sender, EventArgs e)
        {
            query = "select * from medicine";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            query = "select Cat from Catagory";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!cmbCategory.Items.Contains(val))
                {
                    cmbCategory.Items.Add(val);
                }
            }

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medicine where Med_Name Like '" + textBox1.Text + "%'";
            ds = rp.getdata(query);
            r = ds.Tables["0"].Rows.Count;
            if (r > 0)
            {
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
        }

        private void sfButton5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMed_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPinP_TextChanged(object sender, EventArgs e)
        {
            if (txtPinP.Text != "")
            {
                PiP = Convert.ToInt32(txtPinP.Text);
            }
        }

        private void txtPurchasePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPiecePack_TextChanged(object sender, EventArgs e)
        {
            if (txtPiecePack.Text != "")
            {
                QPP = Convert.ToInt32(txtPiecePack.Text);
                qty = PiP * QPP;
                qty = (float)(Math.Truncate((double)qty * 100.0) / 100.0);
                txtQty.Text = qty.ToString();
                if (txtPurchasePrice.Text != "")
                {
                    pPrice = Convert.ToInt32(txtPurchasePrice.Text);
                    ppp = pPrice / qty;
                    ppp = (float)(Math.Truncate((double)ppp * 100.0) / 100.0);
                    txtPPP.Text = ppp.ToString();
                }
                if (txtSalePrice.Text != "")
                {
                    sPrice = Convert.ToInt32(txtSalePrice.Text);
                    spp = sPrice / qty;
                    spp = (float)(Math.Truncate((double)spp * 100.0) / 100.0);
                    txtSPP.Text = spp.ToString();
                }
                if (txtReorderQty.Text != "")
                {
                    ReorderP = Convert.ToInt32(txtReorderQty.Text);
                    stock = qty + ReorderP;
                    txtStock.Text = stock.ToString();
                }
                else
                {
                    stock = qty;
                    txtStock.Text = stock.ToString();
                }
                

            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    query = "UPDATE medicine SET Med_Name = '" + txtMed.Text + "', Cat = '" + cmbCategory.Text + "', Weight = '" + txtWeight.Text + "' WHERE Med_Name = '" + textBox1.Text + "'";
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Updated Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from medicine";
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
                dr = (MessageBox.Show("Search the med you want to edit.","Search", MessageBoxButtons.OK,MessageBoxIcon.Error));
            }
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                query = "SELECT Stock FROM medicine WHERE Med_Name = '" + textBox1.Text + "'";
                ds = rp.getdata(query);
                r = ds.Tables["0"].Rows.Count;
                if (r > 0)
                {
                    string Stringstock = ds.Tables["0"].Rows[0][0].ToString();
                    stock = Convert.ToInt32(Stringstock);
                    stock = reorderQ + stock;
                    try
                    {
                        query = "UPDATE medicine SET Stock = '" + stock.ToString() + "' WHERE Med_Name = '" + textBox1.Text + "'";
                        rp.savdelup(query);
                        dr = (MessageBox.Show("Updated Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                        textBox1.Clear();
                        query = "select * from medicine";
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
                    dr = (MessageBox.Show("No Medicine Exist of this name.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Error));
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                dr = (MessageBox.Show("Search the med you want to update.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    query = "DELETE FROM medicine WHERE Med_Name = '" + textBox1.Text + "'";
                    rp.savdelup(query);
                    dr = (MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    textBox1.Clear();
                    query = "select * from medicine";
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
                dr = (MessageBox.Show("Select a valid Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information));
                textBox1.Focus();
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReorderQty_TextChanged(object sender, EventArgs e)
        {
            if (txtReorderQty.Text != "")
            {
                reorderQ = Convert.ToInt32(txtReorderQty.Text);
            }
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPPP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSPP_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (txtMed.Text != "")
            {
                if (txtPinP.Text != "")
                {
                    if (txtPurchasePrice.Text != "")
                    {
                        if (txtSalePrice.Text != "")
                        {
                            if (txtPiecePack.Text != "")
                            {
                                if (cmbCategory.Text != "")
                                {
                                    if (txtWeight.Text != "")
                                    {
                                        if (txtStock.Text != "")
                                        {
                                            if (txtPPP.Text != "")
                                            {
                                                if (txtSPP.Text != "")
                                                {
                                                    query = "INSERT INTO medicine (Med_Name, Piece_in_Pack, Qty_Per_Pack, Qty, Cat, Purchase_Price, Sale_Price, Weight, Reorder_Qty, Stock, P_P_Piece, S_P_Piece, Exp_Date, Date)" +
                                                        " VALUES ('" + txtMed.Text + 
                                                        "', '" + txtPinP.Text + 
                                                        "', '" + txtPiecePack.Text + 
                                                        "', '" + txtQty.Text + 
                                                        "', '" + cmbCategory.Text + 
                                                        "', '" + txtPurchasePrice.Text + 
                                                        "', '" + txtSalePrice.Text + 
                                                        "', '" + txtWeight.Text + 
                                                        "', '" + txtReorderQty.Text + 
                                                        "', '" + txtStock.Text + 
                                                        "', '" + txtPPP.Text + 
                                                        "', '" + txtSPP.Text + 
                                                        "', '" + dateTimePicker2.Text + 
                                                        "', '" + dateTimePicker1.Text + "')";
                                                    try
                                                    {
                                                        rp.savdelup(query);
                                                        dr = (MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                                        txtMed.Clear(); txtPinP.Clear(); txtPiecePack.Clear(); txtQty.Clear(); txtPurchasePrice.Clear(); txtSalePrice.Clear(); txtWeight.Clear();
                                                        txtReorderQty.Clear(); txtStock.Clear(); txtPPP.Clear(); txtSPP.Clear();
                                                        query = "select * from medicine";
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
                                                    dr = (MessageBox.Show("Enter Purchase S/P/Piece", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                                }
                                            }
                                            else
                                            {
                                                dr = (MessageBox.Show("Enter P/P/Piece", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                            }
                                        }
                                        else
                                        {
                                            dr = (MessageBox.Show("Enter Stock", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                        }
                                    }
                                    else
                                    {
                                        dr = (MessageBox.Show("Enter weight", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                    }
                                }
                                else
                                {
                                    dr = (MessageBox.Show("Select Catagory", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                                }
                            }
                            else
                            {
                                dr = (MessageBox.Show("Enter Piece in Packing", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                            }
                        }
                        else
                        {
                            dr = (MessageBox.Show("Enter Sale Price", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                        }
                    }
                    else
                    {
                        dr = (MessageBox.Show("Enter Purchase Price", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    }
                }
                else
                {
                    dr = (MessageBox.Show("Enter Piece in Packing", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information));
                }
            }
            else
            {
                dr = (MessageBox.Show("Enter Medicine Name","Required",MessageBoxButtons.OK,MessageBoxIcon.Information));
            }
        }
    }
}
