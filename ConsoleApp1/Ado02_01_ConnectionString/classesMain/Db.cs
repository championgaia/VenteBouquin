using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado02_01_ConnectionString
{
    public class Db
    {
        public static string ConnectionString
        { 
            get
            {
                return ConfigurationManager.ConnectionStrings["NorthWind"].ToString();
            }
        }
    }
}
