using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class DatasetExemple
    {
        public void Execute()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT TOP 100* FROM Customers";

                DataSet dataSet = new DataSet();
                SqlCommand command = new SqlCommand(queryText, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(dataSet);

                for (int i = 0; i <= dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    System.Diagnostics.Debug.WriteLine(dataSet.Tables[0].Rows[i].ItemArray[0] + " -- " + dataSet.Tables[0].Rows[i].ItemArray[1]);
                }
            }


        }

    }
}
