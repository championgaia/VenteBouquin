using DemoAdo.NET.Repositories;
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

            var rrr = new ProcedureStockeeExemple();
            rrr.GetSalesByCategoryResults();



            var c = new CustomerRepository();
            var customer = c.GetCustomerById("BLONP");


            var test = new trycatchexamples();
            // test.Example1();
            //test.Example2();
            // test.Example3(null);




            //l'execution continue meme si une des urls pose probleme.
            var htmlData = test.ExampleDownload("http://www.toto.com");
            test.ExampleDownload("http://www.google.com");
            test.ExampleDownload("http://www.amazon.fr");
           
            //  test.ExampleDownload2();

            test.GetDate("2018-12-12");
            test.GetDate("");

            Console.WriteLine("Autres traitements");

            //var simpleSlect = new SimpleSelect();
            //simpleSlect.Execute();

            // var s = new SelectParametre();
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
           var resultats = p.GetCustOrderHistResults("BLONP");

            //var d = new DatasetExemple();
            //d.Execute();

        }




    }
}
