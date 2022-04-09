using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVaddes.Data
{
    public class DbConnection : ConfigurationSection

    {

        public SqlConnection con;
        public void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
            con = new SqlConnection(constring);
        }
    }
}
