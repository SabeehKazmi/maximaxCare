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
    public partial class Reports : MetroFramework.Forms.MetroForm
    {
        //basic declaration
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        String query;
        int r;
        DialogResult dr = new DialogResult();
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            query = "select P_Type from Patient_Type";
            ds = rp.getdata(query);
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
            }
            query = "select * from Patient";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Patient p = new Patient();
            p.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from Patient where P_Type = '" + comboBox1.Text + "' and Date = '" + dateTimePicker1.Text + "' ";
            ds = rp.getdata(query);
            dataGridView1.DataSource = ds.Tables["0"].DefaultView;


            int count = ds.Tables["0"].Rows.Count;
            textBox1.Text = count.ToString();

            query = "select Fee from Patient where P_Type = '" + comboBox1.Text + "' and Date = '" + dateTimePicker1.Text + "' ";
            ds = rp.getdata(query);
            int total = 0;
            textBox2.Text = total.ToString();
            for (int i = 0; i < ds.Tables["0"].Rows.Count; i++)
            {
                var val = ds.Tables["0"].Rows[i][0].ToString();
                total = total + Convert.ToInt32(val);
                textBox2.Text = total.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton8_Click(object sender, EventArgs e)
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
