using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET.Repositories
{
    public class CustomerRepository
    {
        public Customer GetCustomerById(string customerId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT TOP 1 * FROM Customers WHERE CustomerId = @customerId";

                // syntaxe avec AddWithValue
                SqlCommand command = new SqlCommand(queryText, connection);
                command.Parameters.AddWithValue("@customerId", customerId);

                SqlDataReader reader = command.ExecuteReader();

                var c = new Customer();
                while (reader.Read())
                {
                    c.CustomerId = reader["CustomerId"].ToString();
                    c.CompanyName = reader["CompanyName"].ToString();
                    c.ContactName = reader["ContactName"].ToString();
                }
                reader.Close();
                return c;
            }
        }
        public List<Customer> GetCustomersByCountry(string country)
        {
            return null;
        }
        public void UpdateCustomerCity(string customerId,string city)
        {

        }
        public void DeleteCustomerByName(string customerName)
        {

        }
    }
}
