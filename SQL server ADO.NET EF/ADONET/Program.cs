using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    class Program
    {
        static void Main(string[] args)
        {

            //var simpleSlect = new SimpleSelect();
            //simpleSlect.Execute();

            var s = new SelectParametre();
            //var customer = s.Execute2();

            //if(String.IsNullOrEmpty(customer.CustomerId) )
            //    throw new Exception("Customer invalide");

            //int nbCustomersPourVille =s.ExecuteScalarNbCustomersPourVille("london");

          // var results =  s.GetListeCommande("Cunewalde");


            //var scalar = new ExecuteScalarExemple();
            //int result = scalar.Execute();
            //if(result == 0)
            //{
            //    throw new Exception("Nombre egal à zero");
            //}


            //var nonquery = new ExecuteNoNQueryExample();
            //nonquery.Execute2("OSLO", "ANTON");


            var p = new ProcedureStockeeExemple();
            p.GetSalesByCategoryResults();


            //var d = new DatasetExemple();
            //d.Execute();

        }




    }
}
