using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado02_01_ConnectionString
{
    public class Manipulation
    {
        #region GetCustomers sans param
        public void GetCustomers()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWind"].ToString();
                connection.Open();
                var query = "select * from customers";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                    }
                }
            }
        }
        #endregion
        #region GetCustomers avec param @city
        public void GetCustomers(string city)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWind"].ToString();
                connection.Open();
                //var query = "select * from customers where city=" +city;
                
                var query = "select * from customers where city=@city";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@city", city);

                /*version ancien
                 * command.Parameters.Add("@city", SqlDbType.VarChar);
                 * command.Parameters["@city"].Value = city;
                 * */
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                    }
                }
            }
        }
        #endregion
        #region GetCustomers avec param @city en mettre dans une classe
        public Customer GetCustomersClass(string city)
        {
            Customer client = new Customer();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWind"].ToString();
                connection.Open();
                //var query = "select * from customers where city=" +city;

                var query = "select * from customers where city=@city";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@city", city);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client = new Customer
                        {
                            CompanyName = reader["CompanyName"].ToString(),
                            ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                            CustomerId = reader["CustomerId"].ToString()
                        };
                    }
                }
            }
            return client;
        }
        #endregion
        #region GetCustomers avec param @city par une PS
        public void GetSalesByCategoryPS(string nomCategory, string nomPS, string nomVariableSql)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(nomPS, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue(nomVariableSql, nomCategory);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("\t{0}\t{1}",
                        reader[0], reader[1]);
                    }
                }
            }
            /* A Faire
             * chaque PS peut avoir plusieur variable
             * If faut mettre un Dictionaire (nomVariable, nomCategory)
             * 
             * */
        }
        #endregion
        #region GetCustomers avec param @city par une PS
        public void GetSalesByCategoryDictionaryPS(string nomPS, Dictionary<string, string> myDic)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();
                Customer client = new Customer();/////////////////////////////////////////////////////
                SqlCommand command = new SqlCommand(nomPS, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //chercher element dans la dictionaire
                foreach (var item in myDic)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ////////////////////////////////////////////////////////////////////////////
                        client = new Customer
                        {
                            
                            CompanyName = reader["CompanyName"].ToString(),
                            ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                            CustomerId = reader["CustomerId"].ToString()
                        };
                    }
                }
            }
            /* A Faire
             * nomPS à passer en params
             * chaque PS peut avoir plusieur params
             * If faut mettre un Dictionaire (@Variable, variable)
             * comment on fait retour un liste d'objet pour transformer apres
             * */
        }
        #endregion
    }
}
