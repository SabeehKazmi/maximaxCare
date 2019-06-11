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
    public partial class Inventory : MetroFramework.Forms.MetroForm
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.Show();
        }

        private void addCateguryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCat ac = new AddCat();
            ac.Show();
        }

        private void addMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMed am = new AddMed();
            am.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel p = new Panel();
            p.Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Authorization a = new Authorization();
            a.Show();
        }
    }
}
