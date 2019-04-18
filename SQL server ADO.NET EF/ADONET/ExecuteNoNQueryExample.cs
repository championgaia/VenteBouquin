using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    class ExecuteNoNQueryExample
    {
        internal void Execute()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "UPDATE Customers SET City ='BERLIN' WHERE CustomerId = 'ANTON' ";
                SqlCommand command = new SqlCommand(queryText, connection);

                // retourne le nombre de lignes affectées
                int nbLignesaffectees = command.ExecuteNonQuery();
            }


        }
        internal void ExecuteNonQuery2InjectionSql(string city, string customerId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "UPDATE Customers SET City ='"+city+"' WHERE CustomerId ='"+customerId+"'";

                SqlCommand command = new SqlCommand(queryText, connection);

                // retourne le nombre de lignes affectées
                int nbLignesaffectees = command.ExecuteNonQuery();
            }
        }
    }
}
