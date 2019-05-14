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
    public partial class Stock : MetroFramework.Forms.MetroForm
    {
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            query = "select Med_Name, Cat, Stock, Exp_Date from medicine";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMedi_TextChanged(object sender, EventArgs e)
        {
            query = "select Med_Name, Cat, Stock, Exp_Date from medicine where Med_Name Like '" + txtMedi.Text + "%'";
            ds = rp.getdata(query);
            r = ds.Tables["0"].Rows.Count;
            if (r > 0)
            {
                dataGridView1.DataSource = ds.Tables["0"].DefaultView;
            }
            else
            {
                query = "select Med_Name, Cat, Stock, Exp_Date from medicine where Cat Like '" + txtMedi.Text + "%'";
                ds = rp.getdata(query);
                r = ds.Tables["0"].Rows.Count;
                if (r > 0)
                {
                    dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                }
                else
                {
                    query = "select Med_Name, Cat, Stock, Exp_Date from medicine where Stock Like '" + txtMedi.Text + "%'";
                    ds = rp.getdata(query);
                    r = ds.Tables["0"].Rows.Count;
                    if (r > 0)
                    {
                        dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                    }
                    else
                    {
                        query = "select Med_Name, Cat, Stock, Exp_Date from medicine where Exp_Date Like '" + txtMedi.Text + "%'";
                        ds = rp.getdata(query);
                        r = ds.Tables["0"].Rows.Count;
                        if (r > 0)
                        {
                            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
                        }
                    }
                }
            }
        }
    }
}
