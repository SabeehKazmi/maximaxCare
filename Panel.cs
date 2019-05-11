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
    public partial class Panel : MetroFramework.Forms.MetroForm
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void Panel_Load(object sender, EventArgs e)
        {

        }

        private void sfButton5_Click(object sender, EventArgs e)
        {
            Inventory In = new Inventory();
            In.Show();
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            PointofSale pos = new PointofSale();
            pos.Show();
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            Returning r = new Returning();
            r.Show();
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
        }

        private void sfButton6_Click(object sender, EventArgs e)
        {
            HRMS hrms = new HRMS();
            hrms.Show();
        }

        private void sfButton7_Click(object sender, EventArgs e)
        {
            Accounts a = new Accounts();
            a.Show();
        }

        private void sfButton8_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }
    }
}
