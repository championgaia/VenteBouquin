using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class ProcedureStockeeExemple
    {
        
        public List<Resultat> GetSalesByCategoryResults(string categoryName="Beverages")
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand("SalesByCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                var res = new List<Resultat>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var resultat = new Resultat();
                        resultat.ProductName = (string)reader["ProductName"];
                        resultat.TotalPurchase = (decimal)reader["TotalPurchase"];
                        res.Add(resultat);
                    }
                }
                return res;
            }
        }
        //Exercice : Creer une methode comme ci dessous pour recuperer les resultats
        //de la procédure CustOrderHist pour le customerId BLONP
        public List<CustOrderHistResultat> GetCustOrderHistResults(string customerId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Db.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand("CustOrderHist", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId", customerId);

                var res = new List<CustOrderHistResultat>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var resultat = new CustOrderHistResultat();
                        resultat.ProductName = (string)reader["ProductName"];
                        resultat.Total = (int)reader["Total"];
                        res.Add(resultat);
                    }
                }
                return res;
            }
        }




    }
}
