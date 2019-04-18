using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class SelectParametre
    {
        public void Execute(string city = "Berlin")
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                //A eviter - ATTAQUE PAR INJECTION SQL 
                var queryText = "SELECT TOP 100 * FROM Customers WHERE City =" + city;

                SqlCommand command = new SqlCommand(queryText, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                }
                reader.Close();
            }
        }
        public Customer Execute2(string city = "Berlin")
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT TOP 100 * FROM Customers WHERE City = @city";

                // syntaxe avec AddWithValue
                SqlCommand command = new SqlCommand(queryText, connection);
                command.Parameters.AddWithValue("@city", city);

                //Syntaxe avec Add
                //SqlCommand command = new SqlCommand(queryText, connection);
                //command.Parameters.Add("@city", SqlDbType.VarChar);
                //command.Parameters["@city"].Value = city;

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
        public List<Order> GetListeCommande(string shipcity)
        {
            var res = new List<Order>();

            /* SELECT TOP (1000) [OrderID]      ,[EmployeeID]      ,[ShipName]      ,[ShipAddress]
            FROM[NorthwindDb].[dbo].[Orders]
            where shipcity = 'CuneWalde' */
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT [OrderID],[EmployeeID]      ,[ShipName]      ,[ShipAddress] FROM Orders WHERE shipcity = @city";

                // syntaxe avec AddWithValue
                SqlCommand command = new SqlCommand(queryText, connection);
                command.Parameters.AddWithValue("@city", shipcity);

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Order o = new Order();
                    //o.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeID"));
                    //o.ShipAddress = reader.GetString(reader.GetOrdinal("ShipAddress"));
                    //o.ShipName = reader.GetString(reader.GetOrdinal("ShipName"));
                    //o.OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"));

                    o.EmployeeId = (int)reader["EmployeeID"];
                    o.ShipAddress = (string)reader["ShipAddress"];
                    o.OrderId = (int)reader["OrderId"];
                    o.ShipName = reader["ShipName"].ToString();


                    res.Add(o);
                }

            }
            return res;
        }
        public List<Order> GetListCommandesSolution(string city)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT TOP 100 * FROM Orders WHERE ShipCity = @city";

                SqlCommand command = new SqlCommand(queryText, connection);
                command.Parameters.AddWithValue("@city", city);

                SqlDataReader reader = command.ExecuteReader();
                var listOrders = new List<Order>();

                while (reader.Read())
                {
                    var order = new Order();
                    order.OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                    order.ShipName = reader["ShipName"].ToString();
                    order.ShipAddress = reader.GetString(reader.GetOrdinal("ShipAddress"));
                    order.EmployeeId = (int)reader["EmployeeId"];

                    listOrders.Add(order);

                }
                reader.Close();
                return listOrders;
            }


        }

        public int ExecuteScalarNbCustomersPourVille(string city )
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                var queryText = "SELECT count(*) FROM Customers WHERE City = @city";

                SqlCommand command = new SqlCommand(queryText, connection);
                command.Parameters.AddWithValue("@city", city);

                return (int)command.ExecuteScalar();
            }
        }
        

    }
}
