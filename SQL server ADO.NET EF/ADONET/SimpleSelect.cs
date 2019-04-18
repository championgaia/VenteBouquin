using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class SimpleSelect
    {
        public void Execute()
        {
            
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindDb2"].ToString();

                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP 100 * FROM Customers", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                }
                    
                //reader.Close();
            }
        }
    }
}
