using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class ExecuteScalarExemple
    {
        public int Execute()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT COUNT(*) FROM Customers";
                SqlCommand command = new SqlCommand(queryText, connection);

                int result = (int)command.ExecuteScalar();
                
                return result;
            }
        }

    }
}
