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
    public partial class Splash : Form //MetroFramework.Forms.MetroForm
    {
        private Timer closeTimer = new Timer();
        public Splash()
        {
            InitializeComponent();

            closeTimer.Interval = 3000; //3 seconds
            closeTimer.Tick += new EventHandler(closeTimer_Tick);
            closeTimer.Start();
        }
        private void closeTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.WindowState = FormWindowState.Minimized;
            Authorization p = new Authorization();
            p.Show();

            /*
            DialogResult dr = new DialogResult();
            dr = (MessageBox.Show("Procceed?", "Enterance", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (dr == DialogResult.Yes)
            {
                Splash s = new Splash();
                s.Close();
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
