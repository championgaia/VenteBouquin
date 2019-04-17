using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class TransactionExemple
    {

        public void Execute()
        {
            SqlTransaction trans;

            var sqlCommandList = new List<string>();
            sqlCommandList.Add("INSERT INTO dbo.Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES('ALFKI2', 'Alfreds Futterkiste2', 'Maria Anders', 'Sales Representative', 'Obere Str. 57', 'Berlin', NULL, '12209', 'Germany', '030-0074321', '030-0076545')");

            sqlCommandList.Add("INSERT INTO dbo.Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES('ALFKI3', 'Alfreds Futterkiste3', 'Maria Anders', 'Sales Representative', 'Obere Str. 57', 'Berlin', NULL, '12209', 'Germany', '030-0074321', '030-0076545')");

            SqlConnection connection = new SqlConnection(Db.ConnectionString);
            trans = connection.BeginTransaction();
            try
            {
                connection.Open();
                foreach (var commandString in sqlCommandList)
                {
                    SqlCommand command = new SqlCommand(commandString, connection, trans);
                    command.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex) //error occurred
            {
                trans.Rollback();
                //Handel error
            }

        }

    }
}
