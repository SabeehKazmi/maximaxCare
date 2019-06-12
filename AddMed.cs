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
        //basic referances declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query, query1;
        int r;
        DialogResult dr = new DialogResult();
        // these variables required because performing some mathematical operations
        float PiP, QPP, qty, pPrice, sPrice, ReorderP, ppp, spp, stock;
        int reorderQ;
        public AddMed()
        {
            InitializeComponent();
        }

        private void AddMed_Load(object sender, EventArgs e)
        {
            //gridview medicine date show and add items into combobox
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
            //searching medicine according to a specific name
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMed_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPinP_TextChanged(object sender, EventArgs e)
        {
            //piece in packing
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
            // the mathematical code that will do all the caculation on the basiis of pip and price
            if (txtPiecePack.Text != "")
            {
                //measure the total number of medicines available in quantity
                QPP = Convert.ToInt32(txtPiecePack.Text);
                qty = PiP * QPP;
                qty = (float)(Math.Truncate((double)qty * 100.0) / 100.0);
                txtQty.Text = qty.ToString();
                if (txtPurchasePrice.Text != "")
                {
                    //purchase per piece calculation
                    pPrice = Convert.ToInt32(txtPurchasePrice.Text);
                    ppp = pPrice / qty;
                    ppp = (float)(Math.Truncate((double)ppp * 100.0) / 100.0);
                    txtPPP.Text = ppp.ToString();
                }
                if (txtSalePrice.Text != "")
                {
                    //sale per piece calculation
                    sPrice = Convert.ToInt32(txtSalePrice.Text);
                    spp = sPrice / qty;
                    spp = (float)(Math.Truncate((double)spp * 100.0) / 100.0);
                    txtSPP.Text = spp.ToString();
                }
                if (txtReorderQty.Text != "")
                {
                    //if the stock got reordered and arrived so thats the way we enter it. 
                    //initially it will remain 0 then next tie for a specific product the stock arrived will be added into this
                    ReorderP = Convert.ToInt32(txtReorderQty.Text);
                    stock = qty + ReorderP;
                    txtStock.Text = stock.ToString();
                }
                else
                {
                    //total quantity available
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
                    //update the medicine in table if something wrong entered or new stock reordered entered
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
                //search the stock from medicine table according to a specific medicine by its name Med_Name
                query = "SELECT Stock FROM medicine WHERE Med_Name = '" + textBox1.Text + "'";
                ds = rp.getdata(query);
                r = ds.Tables["0"].Rows.Count;
                if (r > 0)
                {
                    //updation of a specific medicine over name code
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
                    //reenter the medicine name again
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

        private void sfButton6_Click(object sender, EventArgs e)
        {
            this.Close();
            Inventory i = new Inventory();
            i.Show();
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    //medicine deletion
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
            //validations
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
                                                    //insertion of a new medicine
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
                                                    string med = "Medicine";
                                                    //and also when it will be bought from us it will also be cost to us
                                                    //so its also got added into expense table
                                                    query1 = "INSERT INTO Expense (Date, Expense_Head, Expense_Amount, Med_Name, Qty) " +
                                                        "VALUES ('" + dateTimePicker1.Text +
                                                        "', '" + med +
                                                        "', '" + txtPurchasePrice.Text +
                                                        "', '" + txtMed.Text +
                                                        "', '" + txtQty.Text + "')";
                                                    try
                                                    {
                                                        rp.savdelup(query);
                                                        rp.savdelup(query1);
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
