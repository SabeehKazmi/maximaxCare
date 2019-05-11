using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MaximaxCare
{
    class Repo
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataSet getdata(string query)
        {
            SqlConnection con = new SqlConnection(@"data source=DESKTOP-FKO8DPG;initial catalog=Maximax;integrated security=true");
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd.CommandText, con);
            ds = new DataSet();
            da.Fill(ds, "0");
            return ds;
        }
        public int savdelup(string query)
        {
            SqlConnection con = new SqlConnection(@"data source=DESKTOP-FKO8DPG;initial catalog=Maximax;integrated security=true");

            con.Open();
            cmd = new SqlCommand(query, con);
            int r = cmd.ExecuteNonQuery();
            con.Close();

            return r;
        }
    }
}
