using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class trycatchexamples
    {

        public void Example1()
        {
            int a = 12;
            int b = 0;

            int c = a / b;//12/0


        }
        public void Example2()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                int a = 12;
                int b = 0;
                connection.Open();
                int c = a / b;//12/0
            }
           catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("on passe bien dans le Finally");
                connection.Close();
            }
            //envoi une exceptio
        }
        public void Example3(string numeroCarte)
        {
           
            if(numeroCarte == null)
            {
                throw new Exception("Numero de carte de credit à renseigner");
            }
            Console.WriteLine("Suite du traitement qu'on accede si numero de carte de credit pas renseigne");


        }

        public void ExampleDownload()
        {
            WebClient wc = null;
            try
            {
                wc = new WebClient(); //downloading a web page
                var resultData = wc.DownloadString("http://google.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception s'est produite : " + ex.Message);
            }
        }
        public string ExampleDownload(string url)
        {
            WebClient wc = null;
            try
            {
                wc = new WebClient(); //downloading a web page
               return  wc.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception s'est produite : " + ex.Message);
            }
            return null;
        }
        public DateTime? GetDate(string datetimeaparser)
        {
            DateTime? value = null;
            try
            {
                value = DateTime.Parse(datetimeaparser,CultureInfo.InvariantCulture);
            }
            catch
            {
            }
            return value;
        }

    }
}
