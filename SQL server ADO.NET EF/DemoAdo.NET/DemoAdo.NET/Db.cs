using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class Db
    {
        public static string ConnectionString
        { 
            get
            {
                return ConfigurationManager.ConnectionStrings["NorthWindDb"].ToString();
            }
        }
    }
}
