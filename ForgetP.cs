using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace MaximaxCare
{
    public partial class ForgetP : MetroFramework.Forms.MetroForm
    {
        Repo rp = new Repo();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        String query, query1;
        int r;
        DialogResult dr = new DialogResult();
        public ForgetP()
        {
            InitializeComponent();
        }

        private void ForgetP_Load(object sender, EventArgs e)
        {

        }

        private void textBoxExt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            query = "SELECT User_Name FROM Author WHERE E_Mail = '" + textBoxExt1.Text + "'";
            query1 = "SELECT Password FROM Author WHERE E_Mail = '" + textBoxExt1.Text + "'";
            ds = rp.getdata(query);
            ds1 = rp.getdata(query1);
            r = ds.Tables["0"].Rows.Count;
            if (r > 0)
            {
                
                string name = ds.Tables["0"].Rows[0][0].ToString();
                string password = ds1.Tables["0"].Rows[0][0].ToString();
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("maximaxcare@gmail.com");
                    mail.To.Add(textBoxExt1.Text);
                    mail.Subject = "User Name and Passowrd Reminder";
                    mail.Body = "User Name: "+ name +" | Password: "+ password;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("MaximaxCare", "MadMax47");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    dr = (MessageBox.Show("Please check your E-Mail", "Authentication", MessageBoxButtons.OK,MessageBoxIcon.Information));
                    if (dr == DialogResult.OK)
                    {
                        Authorization a = new Authorization();
                        a.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }
            else
            {
                dr = (MessageBox.Show("No User Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                if (dr == DialogResult.OK)
                {
                    this.Hide();
                    Authorization a = new Authorization();
                    a.Show();
                }
            }
        }
    }
}
